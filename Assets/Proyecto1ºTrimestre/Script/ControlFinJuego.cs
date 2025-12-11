using TMPro;
using UnityEngine;

public class ControlFinJuego : MonoBehaviour
{
    public TextMeshProUGUI mensajeFinalTexto;
    private ControlDatosJuego datosJuego;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        datosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
        string mensajeFinal = (datosJuego.Ganado) ? "HA GANADO!!" : "HA PERDIDO";
        if (datosJuego.Ganado) mensajeFinal += "Puntuación: " + datosJuego.Puntuacion;

        mensajeFinalTexto.text = mensajeFinal;
    }
}
