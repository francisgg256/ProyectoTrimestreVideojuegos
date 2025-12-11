using UnityEngine;

public class SaltoJugador : MonoBehaviour
{
    public int fuerzaSalto = 10;   
    public int maxSaltos = 2;      
    public LayerMask groundMask;   

    private int saltosRestantes;   
    private Rigidbody2D fisica;
    private GameObject jugador;
    private GameObject player_idle;

    void Start()
    {
        jugador = transform.parent.gameObject;
        player_idle = jugador.transform.Find("player-idle").gameObject;
        fisica = player_idle.GetComponent<Rigidbody2D>();

        
        saltosRestantes = maxSaltos;
    }

    void Update()
    {
        bool enSuelo = TocarSuelo();

        
        if (enSuelo && fisica.linearVelocity.y <= 0.01f)
            saltosRestantes = maxSaltos;

       
        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;

            
            fisica.linearVelocity = new Vector2(fisica.linearVelocity.x, 0);

           
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    
    private bool TocarSuelo()
    {
        
        Vector3 origen = player_idle.transform.position + new Vector3(0, -1f, 0);
        float distancia = 0.2f;

        
        RaycastHit2D toca = Physics2D.Raycast(origen, Vector2.down, distancia, groundMask);

        
        Debug.DrawRay(origen, Vector2.down * distancia,
                      toca.collider != null ? Color.green : Color.red);

        return toca.collider != null;
    }
}



