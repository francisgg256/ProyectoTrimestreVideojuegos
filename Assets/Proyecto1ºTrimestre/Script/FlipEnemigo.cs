using UnityEngine;

public class ControlFlipEnemigo : MonoBehaviour
{
    Vector3 ultimaPosicion;
    private GameObject enemy;
    private GameObject crab_idle;
    private SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = transform.parent.gameObject;
        crab_idle = enemy.transform.Find("EnemySheet_0").gameObject;
        sprite = crab_idle.GetComponent<SpriteRenderer>();
        ultimaPosicion = enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Si va a la derecha flipX = false
        if (enemy.transform.position.x > ultimaPosicion.x) sprite.flipX = false;
        // Si va a la izquierda volteo
        else if (enemy.transform.position.x < ultimaPosicion.x) sprite.flipX = true;
        ultimaPosicion = enemy.transform.position;

    }
}
