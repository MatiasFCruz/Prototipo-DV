using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float tiempo;

    void Start()
    {
        Destroy(gameObject, tiempo);
        
    }

}