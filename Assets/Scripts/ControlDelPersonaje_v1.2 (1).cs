using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlDelPersonaje : MonoBehaviour {
 
    [Header("Variables Movimiento Del Personaje")] // Variables públicas para controlar el movimiento del personaje
    public CharacterController controlador; // Controlador del personaje
    public Transform camara; // Transform de la cámara
    public float velocidadDeMovimiento; // Velocidad de movimiento del personaje
    private Vector3 moveDirection; // Dirección del movimiento del personaje


    [Header("Variables Salto y Suelo")] // Variables públicas para controlar el salto del personaje

    public Transform chequeadorDeSuelo; // Transform del chequeador de suelo
    public float distanciaAlSuelo; // Distancia al suelo
    public LayerMask mascaraDeSuelo; // Máscara de suelo

    Vector3 velocidad; // Vector de velocidad del personaje
    bool estaEnElSuelo; // Verifica si el personaje está en el suelo
    public float gravedad = -9.81f; // Gravedad del personaje
    public float alturaDelSalto; // Altura del salto del personaje

    //Animacion
    [Header("Variables de Animación")]
    public Animator animator; // Animator del personaje


    public string variableMovimiento; // Variable para controlar la animación del movimiento del personaje
    public string variableSuelo; // Variable para controlar la animación del suelo del personaje



    void Start(){
        controlador = GetComponent<CharacterController>(); // Obtiene el controlador del personaje al iniciar
    }

    void Update(){

        estaEnElSuelo = Physics.CheckSphere(chequeadorDeSuelo.position, distanciaAlSuelo, mascaraDeSuelo); // Verifica si el personaje está en el suelo
        if(estaEnElSuelo && velocidad.y <0){
            velocidad.y =-2f;  // Si el personaje está en el suelo, su velocidad en Y se establece a -2f
        }
       
        float horizontalMove = Input.GetAxis("Horizontal");  // Obtención del movimiento horizontal a través del input del usuario
        float verticalMove = Input.GetAxis("Vertical"); // Obtención del movimiento vertical a través del input del usuario

        if (controlador.isGrounded)
        {
            moveDirection = new Vector3(horizontalMove, 0, verticalMove); // Establece la dirección de movimiento en base a la entrada de usuario
            moveDirection = transform.TransformDirection(moveDirection); // Transforma la dirección del movimiento en base a la transformación del personaje
        }

        moveDirection.y -= 1.0f * Time.deltaTime; // Disminuye la velocidad en Y en base a la gravedad en el tiempo transcurrido
        controlador.Move(moveDirection * velocidadDeMovimiento * Time.deltaTime); // Mueve el controlador del personaje en base a la dirección de movimiento y la velocidad de movimiento del personaje
        animator.SetFloat(variableMovimiento, (Mathf.Abs(verticalMove) + Mathf.Abs(horizontalMove))); // Establece la animación del personaje en base al movimiento realizado por el usuario

        if(Input.GetButtonDown("Jump") && estaEnElSuelo){
                velocidad.y = Mathf.Sqrt(alturaDelSalto *-2f * gravedad); // El personaje saltará si se presiona el botón de salto y está en el suelo
        }

        velocidad.y += gravedad * Time.deltaTime; // Aumenta la velocidad en Y en base a la gravedad en el tiempo transcurrido
        controlador.Move(velocidad * Time.deltaTime); // Mueve el controlador del personaje en base a la velocidad del personaje

        animator.SetBool(variableSuelo, controlador.isGrounded); // Establece la animación del personaje en base a si está en el suelo o no
    }
   
}