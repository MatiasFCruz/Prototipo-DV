using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorDeNotas : MonoBehaviour
{
    public GameObject notaVisual;
    public bool activa;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && activa == true)
        {
            notaVisual.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.R) && activa == true)
        {
            notaVisual.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            activa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            activa = false;
        }
    }
}
