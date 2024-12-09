using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("EscenaJuego");
    }
    
    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
