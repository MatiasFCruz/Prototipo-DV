using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPremio : MonoBehaviour
{ 
    public GameObject camara1; //Llamaremos el premio que corresponda.
    public GameObject camara2; //Llamaremos el premio que corresponda.


    // Start is called before the first frame update
    void Start()
    {
        camara1.SetActive(true); //Una vez inicie el juego el premio asignado no se mostrara.
        camara2.SetActive(false);
    }

     void OnCollisionEnter(Collision collision) //Una vez detectada la colision...
    {
        if(collision.gameObject.tag == "Keypad") //Si buscamos el gameObject con la etiqueta "Punto" , entonces...
        {
            camara1.SetActive(false); //Se activara el premio que corresponda.
            camara2.SetActive(true);
        }
    }
     void OnCollisionExit(Collision collision) //Si ya no existe colision...
    {
        if(collision.gameObject.tag == "Keypad") //Si buscamos el gameObject con la etiqueta "Punto" , entonces...
        {
            camara1.SetActive(true); //Se desactivara el premio que corresponda.
            camara2.SetActive(false); //Se desactivara el premio que corresponda.
        }
    }
}
