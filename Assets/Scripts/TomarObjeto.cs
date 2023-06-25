using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarObjeto : MonoBehaviour
{
    public GameObject ObjetoTomar;
    public GameObject ObjetoYaTomado;
    public Transform zonaInteraccion;
    
    void Update()
    {
       if(ObjetoTomar != null && ObjetoTomar.GetComponent<Objeto>().sePuedeTomar == true && ObjetoYaTomado == null)
{
if (Input.GetKeyDown(KeyCode.E))
{
    ObjetoYaTomado = ObjetoTomar;
    ObjetoYaTomado.GetComponent<Objeto>().sePuedeTomar = false;
    ObjetoYaTomado.transform.SetParent(zonaInteraccion);
    ObjetoYaTomado.transform.position = zonaInteraccion.position;
    ObjetoYaTomado.GetComponent<Rigidbody>().useGravity = false;
    ObjetoYaTomado.GetComponent<Rigidbody>().isKinematic = true;
}
}
else if(ObjetoYaTomado != null)
{
    if(Input.GetKeyDown(KeyCode.E))
    {
   
    ObjetoYaTomado.GetComponent<Objeto>().sePuedeTomar = true;
    ObjetoYaTomado.transform.SetParent(null);
    ObjetoYaTomado.GetComponent<Rigidbody>().useGravity = true;
    ObjetoYaTomado.GetComponent<Rigidbody>().isKinematic = false;
    ObjetoYaTomado = null;
    }
}
}
}
