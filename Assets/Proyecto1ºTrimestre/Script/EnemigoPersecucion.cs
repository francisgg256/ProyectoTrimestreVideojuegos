using UnityEngine;

public class EnemigoPersecucion : MonoBehaviour
{
    public float velocidad = 2f;
    public float rangoVision = 5f;
    public Transform jugador;
    public Transform puntoFin;

    private GameObject enemy;
    private Vector3 posicionInicio;
    private Vector3 posicionFin;
    private bool moviendoAFin = true;

    void Start()
    {
        enemy = transform.parent.gameObject;      
        posicionInicio = enemy.transform.position;
        posicionFin = puntoFin.position;
    }

    void Update()
    {
        if (JugadorEnRango())
            PerseguirJugador();
        else
            Patrullar();
    }

    bool JugadorEnRango()
    {
        if (jugador == null) return false;

        float distancia = Vector2.Distance(enemy.transform.position, jugador.position);
        return distancia <= rangoVision;
    }

    void PerseguirJugador()
    {
        Vector3 destino = new Vector3(
            jugador.position.x,
            enemy.transform.position.y,
            enemy.transform.position.z
        );

        enemy.transform.position = Vector3.MoveTowards(
            enemy.transform.position,
            destino,
            velocidad * Time.deltaTime
        );
    }

    void Patrullar()
    {
        Vector3 destino = moviendoAFin ? posicionFin : posicionInicio;

        enemy.transform.position = Vector3.MoveTowards(
            enemy.transform.position,
            destino,
            velocidad * Time.deltaTime
        );

        if (enemy.transform.position == posicionFin) moviendoAFin = false;
        if (enemy.transform.position == posicionInicio) moviendoAFin = true;
    }
}


