using Firebase.Extensions;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Firestore : MonoBehaviour
{
    private static FirebaseFirestore db;

    
    private static FirebaseFirestore GetDB()
    {
        if (db == null)
        {
            try
            {
                db = FirebaseFirestore.DefaultInstance;
                Debug.Log("✅ Firestore inicializado correctamente.");
            }
            catch (Exception e)
            {
                Debug.LogError("❌ Error inicializando Firestore: " + e.Message);
            }
        }
        return db;
    }

    
    public static async Task SaveHighscore(string playerName, float score, float timePlayed, int attempts)
    {
        try
        {
            var database = GetDB(); 

            if (database == null)
            {
                Debug.LogError("Firestore DB sigue siendo null. Revisa configuración Firebase.");
                return;
            }

            DocumentReference docRef = database.Collection("Highscores").Document(playerName);
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                { "Name", playerName },
                { "Score", Mathf.FloorToInt(score) },
                { "TimePlayed", Mathf.FloorToInt(timePlayed) },
                { "Attempts", attempts },
                { "Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }
            };

            await docRef.SetAsync(data);
            Debug.Log($"✅ Puntaje guardado en Firebase para {playerName}");
        }
        catch (Exception e)
        {
            Debug.LogError("❌ Error guardando datos en Firestore: " + e.Message);
        }
    }

  
    public static async Task<List<(string name, int score)>> GetTopScores(int limit = 10)
    {
        var database = GetDB();
        List<(string, int)> ranking = new List<(string, int)>();

        try
        {
            Query query = database.Collection("Highscores").OrderByDescending("Score").Limit(limit);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            foreach (DocumentSnapshot doc in snapshot.Documents)
            {
                string name = doc.ContainsField("Name") ? doc.GetValue<string>("Name") : "???";
                int score = doc.ContainsField("Score") ? doc.GetValue<int>("Score") : 0;
                ranking.Add((name, score));
            }
        }
        catch (Exception e)
        {
            Debug.LogError("❌ Error leyendo ranking: " + e.Message);
        }

        return ranking;
    }
}
