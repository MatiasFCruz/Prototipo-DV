using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuertaCodigo : MonoBehaviour
{

    public AudioSource quienEmite;
    public AudioClip elSonido;
    public float volumen = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        quienEmite.PlayOneShot(elSonido,volumen);
    }
}
