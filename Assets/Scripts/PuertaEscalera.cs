using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaEscalera : MonoBehaviour
{ 
    [SerializeField]
    private GameObject premio; //Llamaremos el premio que corresponda.

    public AudioSource quienEmite;
    public AudioClip elSonido;
    public float volumen = 1f;


    // Start is called before the first frame update
    void Start()
    {
        premio.SetActive(false); //Una vez inicie el juego el premio asignado no se mostrara.
    }

     void OnCollisionEnter(Collision collision) //Una vez detectada la colision...
    {
        if(collision.gameObject.tag == "PuntoFinal") //Si buscamos el gameObject con la etiqueta "Punto" , entonces...
        {
            premio.SetActive(true); //Se activara el premio que corresponda.
            quienEmite.PlayOneShot(elSonido,volumen);

            Destroy(GameObject.Find("CERRADO"));
        }
    }
     void OnCollisionExit(Collision collision) //Si ya no existe colision...
    {
        if(collision.gameObject.tag == "PuntoFinal") //Si buscamos el gameObject con la etiqueta "Punto" , entonces...
        {
            premio.SetActive(false); //Se desactivara el premio que corresponda.
        }
    }
}
