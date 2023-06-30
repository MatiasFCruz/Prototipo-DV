using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoDeteccion : MonoBehaviour
{
    public float rangoAlerta;
    public LayerMask capaJugador;
    bool estarAlerta;
    public Transform jugador;
    public float velocidad;

    //Animacion
    public Animator animator; //Llamamos a las animaciones..
    
   [SerializeField]
   private float velocidadMovimiento;
   [SerializeField]
   private Transform[] puntosMovimiento;
   [SerializeField]
   private float distanciaMinima;

   private int siguientePaso = 0;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.position = Vector3.MoveTowards(transform.position, puntosMovimiento[siguientePaso].position, velocidadMovimiento *Time.deltaTime);
         transform.LookAt(puntosMovimiento[siguientePaso].position);
 
        estarAlerta = Physics.CheckSphere(transform.position,rangoAlerta,capaJugador);
        Debug.Log(estarAlerta);

           if(Vector3.Distance(transform.position, puntosMovimiento[siguientePaso].position) < distanciaMinima)
    {
        siguientePaso += 1;
        if(siguientePaso >= puntosMovimiento.Length)
        {
            siguientePaso = 0;
        }
    }

        if(estarAlerta == true) //Si el jugador entra en el rango del enemigo....
        {
            //transform.LookAt(jugador);
            transform.LookAt(new Vector3(jugador.position.x,transform.position.y,jugador.position.z));
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(jugador.position.x,transform.position.y,jugador.position.z),velocidad * Time.deltaTime);
            animator.SetBool("estaCorriendo",true); //Se activa la animacion de "estaCorriendo"
            animator.SetBool("estaCaminando",false); //Se desactiva la animacion de "estaParado"
        }else{ //Por el contrario si el player sale del rango de deteccion entonces...
            animator.SetBool("estaCorriendo",false); //Se desactiva la animacion de "estaCorriendo"
            animator.SetBool("estaCaminando",true); //Se activa la animacion de de "estaParado"
            transform.position = Vector3.MoveTowards(transform.position, puntosMovimiento[siguientePaso].position, velocidadMovimiento *Time.deltaTime);

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,rangoAlerta);

    }
}
