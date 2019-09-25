using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCore : MonoBehaviour
{
    public GameObject trigger;
    public GameObject targetCore;

    public float speed;

    void Update()
    {
        Vector3 coreDirection = targetCore.transform.position;

        if (trigger.GetComponent<ContactTrigger>().contactTrigger == true)
        {
            transform.position = Vector3.Lerp(transform.position, coreDirection, Time.deltaTime * speed);
        }
    }
}
