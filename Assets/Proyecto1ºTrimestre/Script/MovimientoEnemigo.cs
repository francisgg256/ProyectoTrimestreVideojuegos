using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidad = 2f;
    public Transform puntoFin;

    private GameObject enemy;
    private Vector3 posicionInicio;
    private Vector3 posicionFin;
    private bool moviendoAFin;

    void Start()
    {
        enemy = transform.parent.gameObject;
        posicionInicio = enemy.transform.position;
        posicionFin = puntoFin.position;
        moviendoAFin = true;
    }

    void Update()
    {
        moverEnemigo();
    }

    private void moverEnemigo()
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

