using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{
    public AudioSource quienEmite;
    public AudioClip elArchivo;
    public float volumen = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // Verifica si el objeto que colisionó tiene el tag "Player"
        {
            quienEmite.PlayOneShot(elArchivo, volumen);
            StartCoroutine("TiempoBorrarSonido");
        }
        
    }

    public IEnumerator TiempoBorrarSonido()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
