using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlDelPersonaje : MonoBehaviour {
 
    [Header("Variables Movimiento Del Personaje")]
    public CharacterController controlador;
    public Transform camara;
    public float velocidadDeMovimiento;
    private Vector3 moveDirection;


    [Header("Variables Salto y Suelo")]

    public Transform chequeadorDeSuelo;
    public float distanciaAlSuelo;
    public LayerMask mascaraDeSuelo;

    Vector3 velocidad;
    bool estaEnElSuelo;
    public float gravedad = -9.81f;
    public float alturaDelSalto;

    //Animacion
    [Header("Variables de Animación")]
    public Animator animator;


    public string variableMovimiento;
    public string variableSuelo;



    void Start(){
        controlador = GetComponent<CharacterController>();
    }

    void Update(){

        estaEnElSuelo = Physics.CheckSphere(chequeadorDeSuelo.position, distanciaAlSuelo, mascaraDeSuelo);
        if(estaEnElSuelo && velocidad.y <0){
            velocidad.y =-2f;
        }
       
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (controlador.isGrounded)
        {
            moveDirection = new Vector3(horizontalMove, 0, verticalMove);
            moveDirection = transform.TransformDirection(moveDirection);
        }

        moveDirection.y -= 1.0f * Time.deltaTime;
        controlador.Move(moveDirection * velocidadDeMovimiento * Time.deltaTime);
        animator.SetFloat(variableMovimiento, (Mathf.Abs(verticalMove) + Mathf.Abs(horizontalMove)));

        if(Input.GetButtonDown("Jump") && estaEnElSuelo){
                velocidad.y = Mathf.Sqrt(alturaDelSalto *-2f * gravedad);
        }

        velocidad.y += gravedad * Time.deltaTime;
        controlador.Move(velocidad * Time.deltaTime);

        animator.SetBool(variableSuelo, controlador.isGrounded);
    }
   
}