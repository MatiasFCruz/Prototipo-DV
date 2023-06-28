using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool isUnlocked = true;
    float smooth = 4.0f;
    float DoorOpenAngle = 90.0f;
    private bool open;
    private bool enter;
    private Vector3 defaultRot;
    private Vector3 openRot;
    // Start is called before the first frame update
    void Start()
    {
        // Se guarda la posicion inicial de la visagra
        defaultRot = transform.eulerAngles;

        // Se guarda la posicion final de la visagra

        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isUnlocked)
        {
            if (open)
            {
                transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
            }
            // Si la puerta no esta abierta se cierra
            else
            {
                transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
            }
            if (Input.GetKeyDown("f") && enter)
            {
                // en caso de que sea cierto la variable open tomara el valor de true
                // con esto conseguiremos que cuando unity llame a la funcion update
                // entre en el caso de abrir puerta
                open = !open;

                if (open)
                {
                    // Si se se va a abrir la puerta se asigna la velocidad de movimiento de
                    //apertura de la puerta
                    smooth = 4.0f;
                    // Se asigna el clip de audio al audiosource
                    //audioSource.clip = openDoorAudio;
                    // Se reproduce el sonido
                    //audioSource.Play();
                }
                else
                {
                    // Si se se va a cerrar la puerta se asigna la velocidad de movimiento de
                    //cierre de la puerta
                    smooth = 10.0f;
                    // Se asigna el clip de audio al audiosource
                    //audioSource.clip = closeDoorAudio;
                    // Se repodruce el sonido
                    //audioSource.Play();
                }
            }
        }
    }
    private void OnGUI()
    {
        // Si el player ha entrado en contacto con el collider de la puerta
        if (enter && isUnlocked)
        {
            // Se muestra el mensaje de interaccion
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "PRESIONA 'F'");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Colocamos la variable enter a true
            enter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Si el objeto que ha salido de colision es el player
        if (other.gameObject.tag == "Player")
        {
            // Colocamos la variable enter a false
            enter = false;
        }
    }

}
