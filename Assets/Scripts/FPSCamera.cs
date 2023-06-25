using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public Vector3 sensibility;
    private Transform camara;


    // Start is called before the first frame update
    void Start()
    {
        camara = transform.Find("MainCamera"); //permite encontrar el objeto que se encuentra en la jerarquia
        Cursor.lockState = CursorLockMode.None; //Permite que el cursor del mouse no se salga del juego 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X"); //para saber como se mueve el mouse en forma horizontal
        float vertical = Input.GetAxis("Mouse Y"); //para saber como se mueve el mouse en forma vertical

        if (horizontal != 0)
        {
            transform.Rotate(Vector3.up * horizontal * sensibility.x); //movimiento horizontal y sensibilidad
        }

         if (vertical != 0)
        {
            camara.Rotate(Vector3.left * vertical * sensibility.y); //movimiento horizontal y sensibilidad
          
        }

    }
}
