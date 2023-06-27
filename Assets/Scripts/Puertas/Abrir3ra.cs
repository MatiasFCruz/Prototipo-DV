using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abrir3ra : MonoBehaviour
{
    [SerializeField]
    private GameObject objectThatLooks;
    [SerializeField]
    private GameObject objectToLook;
    [SerializeField]
    private float yPos;
    private Vector3 objectToLookPosition;
    // Start is called before the first frame update
    void Start()
    {
        objectToLook = GameObject.FindGameObjectWithTag("Pasador3");
    }

    void FixedUpdate()
    {
        lookAtObject();
    }

    private void lookAtObject()
    {
        objectToLookPosition = objectToLook.transform.position;
        objectToLookPosition.y = yPos;
        objectThatLooks.transform.LookAt(objectToLookPosition);
    }
}
