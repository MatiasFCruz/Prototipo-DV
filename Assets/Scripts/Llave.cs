using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public Puerta doorToOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doorToOpen.isUnlocked = true;
        }
        Destroy(gameObject);
    }

}
