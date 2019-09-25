using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactTrigger : MonoBehaviour
{
    public bool contactTrigger = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Trigger")
        {
            contactTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Trigger")
        {
            contactTrigger = false;
        }
    }
}
