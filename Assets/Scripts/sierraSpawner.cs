using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sierraSpawner : MonoBehaviour
{
    public GameObject sierraASpawnear;
    [SerializeField] public float velocidad = 2f;  // Intervalo de aparición de las sierras
    float minimoX = -3f;
    float minimoY = 3f;

    // Start is called before the first frame update
    void Start()
    {
        startSpawning();
    }

    void Update()
    {
        // No necesitamos hacer nada en Update
    }

    // Inicia el spawn de las sierras con la velocidad establecida
    public void startSpawning()
    {
        InvokeRepeating("Spawn", 1f, velocidad);  // La velocidad controla el intervalo entre apariciones
    }

    // Detiene el spawn de sierras
    public void stopSpawning()
    {
        CancelInvoke("Spawn");
    }

    // Método para instanciar una sierra en una posición aleatoria
    public void Spawn()
    {
        float randomX = Random.Range(minimoX, minimoY);
        Vector2 posicionDeSapwn = new Vector2(randomX, transform.position.y);
        Instantiate(sierraASpawnear, posicionDeSapwn, Quaternion.identity);
    }

    // Método para aumentar la velocidad de las sierras (disminuir el intervalo)
    public void AumentarVelocidad()
    {
        if (velocidad > 5f)  // Establecemos un límite para no hacer las sierras demasiado rápidas
        {
            velocidad -= 4f;  // Disminuimos el intervalo, haciendo que las sierras caigan más rápido
            CancelInvoke("Spawn");  // Detenemos el Invoke actual
            startSpawning();  // Re-iniciamos el spawn con la nueva velocidad
            Debug.Log("Velocidad de sierras aumentada: " + velocidad);
        }
    }
}
