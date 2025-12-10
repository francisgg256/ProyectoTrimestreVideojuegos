using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{
    private ControlJuego controlJuego;

    void Start()
    {
        controlJuego = FindFirstObjectByType<ControlJuego>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            controlJuego.QuitarVida();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            controlJuego.QuitarVida();
    }
}

