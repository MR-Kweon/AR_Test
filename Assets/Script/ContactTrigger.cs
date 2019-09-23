using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactTrigger : MonoBehaviour
{
    public bool eventActivate = false;

    Renderer myRender;
    public Color contactColor;

    private void Start()
    {
        myRender = GetComponent<Renderer>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Trigger")
        {
            eventActivate = true;
            myRender.material.color = contactColor;
            Debug.Log("접촉");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Trigger")
        {
            eventActivate = false;
            myRender.material.color = Color.white;
        }
    }
}
