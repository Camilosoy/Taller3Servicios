using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private GameController gameController;

    void Start()
    {
       
        gameController = FindFirstObjectByType<GameController>();

        if (gameController == null)
        {
            Debug.LogError("No se encontró un GameController en la escena.");
        }
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        
        float clampedX = Mathf.Clamp(transform.position.x, -8f, 8f);
        transform.position = new Vector3(clampedX, transform.position.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedBall"))
        {
            if (gameController != null)
                gameController.GameOver();
        }
    }
}
