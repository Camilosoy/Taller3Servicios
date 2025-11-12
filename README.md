# 🎮 Juego de Pelotas – Unity + Firebase

Este es un proyecto desarrollado en **Unity** que integra **Firebase Firestore** y **Firebase Analytics** para registrar puntajes, tiempos de juego y analíticos personalizados.

El jugador ingresa su nombre, esquiva pelotas que caen, y al final de la partida su puntaje se guarda automáticamente en la base de datos de Firebase.  
Además, el juego muestra un **ranking con los mejores puntajes** directamente desde Firestore.

---

## 🚀 Características principales

- ✅ Aumento automático de puntaje mientras el jugador está vivo.  
- ✅ Guardado del puntaje y tiempo de sesión en Firebase Firestore.  
- ✅ Colección `Highscores` con los mejores puntajes.  
- ✅ Ranking visible en pantalla al finalizar el juego.  
- ✅ Registro de analíticos personalizados:  
  - Tiempo total jugado  
  - Intentos del jugador  
  - Fecha y hora de cada sesión  

---

## ⚙️ Requisitos

- Unity **2022.3** o superior (LTS recomendado)  
- SDK de **Firebase para Unity** (ya incluido en el proyecto)  
- Una cuenta en [Firebase Console](https://console.firebase.google.com/)  
- Conexión a Internet para el guardado de datos  

---

## 🔧 Configuración de Firebase

Para que el juego funcione correctamente, necesitas conectar **tu propio proyecto Firebase**.  
Sigue estos pasos:

1. Crea un nuevo proyecto en [Firebase Console](https://console.firebase.google.com/).  
2. En el menú lateral, entra en **Firestore Database** y haz clic en **Crear base de datos**.  
   - Modo: *test mode* (modo de prueba)  
   - Ubicación: elige la región más cercana a ti.
3. Luego, en la consola de Firebase, ve a **Project Settings → Tu app → Agregar app de Android**.
4. Usa el mismo **Package Name** que tiene tu proyecto Unity.  
   (Puedes verlo en `File > Build Settings > Player Settings > Identification > Package Name`)
5. Descarga el archivo `google-services.json`.
6. Coloca ese archivo dentro de tu proyecto Unity en la ruta:

7. En el editor de Unity, asegúrate de tener importado el SDK de Firebase y que no haya errores de inicialización en la consola.
8. Ejecuta el juego.  
Si todo está correcto, al terminar una partida verás tu nombre y puntaje guardados en Firebase en la colección **Highscores**.

---

## 🕹️ Cómo jugar

1. **Pantalla de inicio:**  
- Ingresa tu nombre en el campo de texto.  
- Presiona el botón **“Jugar”**.

2. **Durante el juego:**  
- Mueve el jugador con las **flechas izquierda y derecha** o las teclas **A / D**.  
- Esquiva las pelotas rojas que caen.  
- Tu puntaje aumenta automáticamente mientras sobrevives.

3. **Game Over:**  
- Cuando una pelota te golpea, el juego termina.  
- Tu puntaje se guarda automáticamente en Firebase.  
- En pantalla aparecerá un **ranking** con los mejores puntajes globales.

4. **Volver al menú:**  
- Presiona el botón **“Volver al Menú”** para reiniciar o ingresar un nuevo nombre.

---

El proyecto funciona de manera modular y con el modelo Vista Controlador, asi que las carpetas que contienen los scripts estan en controller, model y view, el script de firebase se encuentra afuera, dentro de las 
escenas te interesara observar los managers de cada cosa, ahi es donde se controla casi todo.

