using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
   public string password = "1234";
   private string userInput = "";

   public Transform toOpen;

   //public AudioClip clickSound;
   //public AudioClip openSound;
   //public AudioClip noSound;
   //AudioSource audioSource;

   //public UnityEvent OnEntryAllowed;

   private void start()
   {
    userInput = "";
   //audioSource = GetComponent<AudioSource>();
   }

   public void ButtonClicked(string number)
   {
    //audioSource.PlayOneShot(clickSound);
    userInput += number;

    if(userInput.Length >= 4)
    {
        //check password
        if(userInput == password)
        {
            StartCoroutine(Open());
            //Todo Invoke the event play sound
            Debug.Log("CORRECTO");
            //audioSource.clip = openSound;
            //audioSource.Play();
            //OnEntryAllowed.Invoke();
        }
        else
        {
            Debug.Log("INCORRECTO");
            //Todo play song
            userInput = "";
            //audioSource.PlayOneShot(noSound);
        }

        IEnumerator Open()
    {
        toOpen.Rotate(new Vector3(0,90,0), Space.World);

        yield return new WaitForSeconds(4);

        toOpen.Rotate(new Vector3(0,-90,0), Space.World);

    }
    }
   }
}
