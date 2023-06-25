using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{

    public bool sePuedeTomar = true;

   private void OnTriggerEnter(Collider other)
   {
    if(other.tag == "PlayerInteraccion")
    {
        other.GetComponentInParent<TomarObjeto>().ObjetoTomar = this.gameObject;
    }

   }

   private void OnTriggerExit(Collider other)
   {
    if(other.tag == "PlayerInteraccion")
    {
        other.GetComponentInParent<TomarObjeto>().ObjetoTomar = null;
    }
   }
}
