using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public Puerta doorToOpen;  // Definición de una variable pública de tipo Puerta llamada doorToOpen


    private void OnTriggerEnter(Collider other) // Método que se ejecuta cuando un objeto colisiona con este objeto (en este caso, solo se ejecuta al colisionar un objeto con tag "Player")
    {

        if (other.tag == "Player") // Verifica si el objeto que colisionó tiene el tag "Player"
        {
            doorToOpen.isUnlocked = true; // Marca la puerta asociada con doorToOpen como desbloqueada
            Destroy(gameObject); // Destruye este objeto
        }


     
    }

}
