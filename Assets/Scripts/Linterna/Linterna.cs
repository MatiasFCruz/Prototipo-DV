using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public Light luzLinterna;
    public bool activLight;
    public bool linternaEnMano;
    public AudioSource quienEmite;
    public AudioClip elArchivo;
    public float volumen = 1;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B) && linternaEnMano == true)
        {
            activLight = !activLight;

            if(activLight == true)
            {
                luzLinterna.enabled = true;
                quienEmite.PlayOneShot(elArchivo, volumen);
            }

            if(activLight == false)
            {
                luzLinterna.enabled = false;
                quienEmite.PlayOneShot(elArchivo, volumen);
            }
        }
    }
}