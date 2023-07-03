using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    public GameObject camaraA, camaraB;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            camaraA.SetActive(false);
            camaraB.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        camaraA.SetActive(true);
        camaraB.SetActive(false);
    }
}
