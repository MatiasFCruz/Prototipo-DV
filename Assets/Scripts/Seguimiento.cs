using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seguimiento : MonoBehaviour
{
   [SerializeField]
   NavMeshAgent agente;

   [SerializeField]
   private float velocidadMovimiento;
   [SerializeField]
   private Transform[] puntosMovimiento;
   [SerializeField]
   private float distanciaMinima;

   private int siguientePaso = 0;


void Start()
{
  
    if (TryGetComponent(out NavMeshAgent navAgent))
    {
        agente = navAgent;
    }


}

private void Update()
{
    transform.position = Vector3.MoveTowards(transform.position, puntosMovimiento[siguientePaso].position, velocidadMovimiento *Time.deltaTime);
    
    if(Vector3.Distance(transform.position, puntosMovimiento[siguientePaso].position) < distanciaMinima)
    {
        siguientePaso += 1;
        if(siguientePaso >= puntosMovimiento.Length)
        {
            siguientePaso = 0;
        }
    }
}

  

}