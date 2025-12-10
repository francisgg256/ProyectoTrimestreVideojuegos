using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public int velocidad;

    private float entradaX;
    private Rigidbody2D fisica;
    private GameObject player_idle;
    private GameObject jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = transform.parent.gameObject;
        player_idle = jugador.transform.Find("player-idle").gameObject;
        fisica = player_idle.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        entradaX = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        fisica.linearVelocity = new Vector2(entradaX * velocidad, fisica.linearVelocityY);
    }
}
