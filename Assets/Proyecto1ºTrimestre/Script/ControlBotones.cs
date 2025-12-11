using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlBotones : MonoBehaviour
{
    public void OnBotonJugar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void OnBotonCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void OnBotonSalir()
    {
        Application.Quit();
    }

    public void OnBotonMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
