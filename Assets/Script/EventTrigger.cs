using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public bool eventTrigger = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Eventor")
        {
            eventTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Eventor")
        {
            eventTrigger = false;
        }
    }
}
