using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
  public GameObject susto;

  private void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player"))
    {
        Instantiate(susto);
        
    }
  }
}
