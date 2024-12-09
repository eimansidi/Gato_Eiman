using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    float velocidad = -11.0f;

    void Awake()
    {
        // Aquí puedes inicializar cualquier cosa si es necesario
    }

    void FixedUpdate()
    {
        // Este movimiento hace que el obstáculo rote constantemente
        transform.Rotate(0, 0, velocidad);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el obstáculo toca el suelo, se destruye
        if (collision.tag == "suelo")
        {
            Destroy(gameObject);  // El obstáculo se destruye
            GameManager.Instance.setScore();  // Aumenta el puntaje
        }

        // Si el obstáculo toca al jugador
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            // Si el jugador tiene vidas restantes
            if (GameManager.Instance.vidas > 0)
            {
                // Llamamos al método RestarVida del GameManager para restar una vida
                GameManager.Instance.RestarVida();

                // Verificamos si las vidas llegaron a 0
                if (GameManager.Instance.vidas == 0)
                {
                    // El jugador desaparece solo cuando las vidas llegan a 0
                    Destroy(collision.gameObject);  // Destruir el jugador
                    GameManager.Instance.GameOver();  // Terminar el juego
                }
            }
        }
    }
}
