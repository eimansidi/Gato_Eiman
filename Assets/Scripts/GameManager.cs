using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int vidas = 3;  // Vidas iniciales
    public int score = 0;  // Puntaje
    public Text marcador;  // UI para mostrar el puntaje
    public Image[] vidasImagenes;  // Imágenes para las vidas
    public GameObject gameOverPanel;  // Panel de Game Over

    private bool gameOver = false;
    private int contadorColisiones = 0;  // Contador de colisiones con los obstáculos

    private void Awake()
    {
        Instance = this;
    }

    // Método para restar una vida
    public void RestarVida()
    {
        if (!gameOver)
        {
            vidas--;  // Resta una vida

            // Actualiza las imágenes de las vidas
            if (vidas >= 0 && vidas < vidasImagenes.Length)
            {
                vidasImagenes[vidas].enabled = false;  // Desactiva la imagen de la vida
            }

            // Verifica si las vidas llegaron a 0
            if (vidas <= 0)
            {
                GameOver();  // Si las vidas son 0, termina el juego
            }
        }
    }

    // Método para aumentar el puntaje y gestionar las colisiones
    public void setScore()
    {
        if (!gameOver)
        {
            score++;  // Aumenta el puntaje
            marcador.text = score.ToString();  // Actualiza el puntaje en la UI

            // Incrementa el contador de colisiones
            contadorColisiones++;

            // Verifica si el jugador ha esquivado 10 sierras
            if (contadorColisiones >= 10)
            {
                // Solo agregar vida si el jugador tiene menos de 3 vidas
                if (vidas < 3)
                {
                    AñadirVida();  // Agregar 1 vida
                }

                // Reinicia el contador de colisiones
                contadorColisiones = 0;
            }
        }
    }

    // Método para agregar una vida
    private void AñadirVida()
    {
        if (vidas < 3)  // Solo se agrega una vida si el jugador tiene menos de 3
        {
            vidas++;  // Aumenta la cantidad de vidas
            if (vidas <= 3 && vidasImagenes.Length >= vidas)
            {
                vidasImagenes[vidas - 1].enabled = true;  // Activa la imagen de la nueva vida
            }
        }
    }

    // Método para finalizar el juego
    public void GameOver()
    {
        gameOver = true;  // Marca el juego como terminado
        GameObject.Find("sierraSpawner").GetComponent<sierraSpawner>().stopSpawning();  // Detenemos el spawn de sierras

        // Cambia a la escena de Game Over (MenuPAL)
        SceneManager.LoadScene("MenuPAL"); 
    }
}
