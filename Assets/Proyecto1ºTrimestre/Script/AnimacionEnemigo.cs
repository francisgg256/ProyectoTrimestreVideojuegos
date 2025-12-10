using UnityEngine;

public class AnimacionEnemigo : MonoBehaviour
{
    private GameObject enemigo;
    private GameObject enemy_idle;
    private Animator animacion;
    private Rigidbody2D fisica;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemigo = transform.parent.gameObject;
        enemy_idle = enemigo.transform.Find("EnemySheet_0").gameObject;
        animacion = enemy_idle.GetComponent<Animator>();
        //fisica = enemy_idle.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //animarJugador();
    }

    private void FixedUpdate()
    {
        animarJugador();
    }

    private void animarJugador()
    {
        if (!tocarSuelo())
        {
            animacion.Play("enemigoSaltando");
        }
        else
        {
            if (fisica.linearVelocity.x == 0 && fisica.linearVelocity.y == 0)
            {
                animacion.Play("enemigoParado");
            }

            if (fisica.linearVelocity.y < 0)
            {
                animacion.Play("enemigoCayendo");
            }
        }
    }

    private bool tocarSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(enemy_idle.transform.position + new Vector3(0, -1.8f, 0), Vector2.down, 0.2f);

        return toca.collider != null;


    }
}

