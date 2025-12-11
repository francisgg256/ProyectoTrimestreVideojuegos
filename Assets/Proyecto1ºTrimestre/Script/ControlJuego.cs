using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ControlJuego : MonoBehaviour
{
    public int numVidas;
    public int puntuacion;
    public int tiempoNivel;

    private int tiempoInicio;
    private int tiempoEmpleado;
    private bool vulnerable;
    private SpriteRenderer sprite;
    private GameObject jugador;
    private GameObject player_idle;
    private Canvas canvas;
    private ControlHUD hud;

    private ControlDatosJuego controlDatosJuego;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip saltoSfx;
    public AudioClip vidaSfx;
    public AudioClip recolectarSfx;
    void Start()
    {
        puntuacion = 0;
        tiempoInicio = (int)Time.time;
        tiempoNivel = 120;
        vulnerable = true;
        jugador = GameObject.FindGameObjectWithTag("Player").gameObject;
        player_idle = jugador.transform.Find("player-idle").gameObject;
        sprite = player_idle.GetComponent<SpriteRenderer>();
        canvas = Canvas.FindFirstObjectByType<Canvas>();
        hud = canvas.GetComponent<ControlHUD>();
        hud.setPuntuacion(puntuacion);
        hud.setNumVidas(numVidas);
        hud.setTiemploEmpleado(tiempoEmpleado);
        controlDatosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("PowerUp").Length == 0)
        {
            GanarJuego();
        }
        //Actualizar tiempo empleado
        tiempoEmpleado = (int)(Time.time - tiempoInicio);
        hud.setTiemploEmpleado(tiempoEmpleado);
        //Comprobar si hemos consumido tiempo nivel
        if (tiempoNivel - tiempoEmpleado < 0) FinJuego();
    }

    public void FinJuego()
    {
        controlDatosJuego.Ganado = false;
        SceneManager.LoadScene("FinNivel");
    }

    public void IncrementarPuntos(int cantidad)
    {
        puntuacion += cantidad;
        hud.setPuntuacion(puntuacion);
    }

    public void QuitarVida()
    {
        if (vulnerable)
        {
            vulnerable = false;
            numVidas--;
            hud.setNumVidas(numVidas);
            if (numVidas == 0)
            {
                FinJuego();
            }
            Invoke("HacerVulnerable", 1f);
            sprite.color = Color.red;
        }
    }

    public void GanarJuego()
    {
        puntuacion = (numVidas * 100) + (tiempoNivel - tiempoEmpleado);
        controlDatosJuego.Puntuacion = puntuacion;
        controlDatosJuego.Ganado = true;
        SceneManager.LoadScene("FinNivel");
    }

    private void HacerVulnerable()
    {
        vulnerable = true;
        sprite.color = Color.white;
    }
}
