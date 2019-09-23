using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCore : MonoBehaviour
{
    public ActiveManager activeManager;
    public ContactTrigger eventOn;
    public GameObject triggerRight;
    public GameObject objectCore;
    public float speed;

    void Update()
    {
        int onCount = activeManager.count;

        bool activate = eventOn.eventActivate;

        Vector3 originDirection = transform.position;

        Vector3 coreDirection = objectCore.transform.position;

        Vector3 spareDirection = new Vector3(-0.15f, -0.15f, -0.15f);

        Vector3 moveDirection = coreDirection - originDirection;

        Vector3 backDirection = triggerRight.transform.position;

        if (onCount == 1)
        {
            if (activate == true)
            {
                transform.position = Vector3.Lerp(transform.position, coreDirection, Time.deltaTime * speed);
            }

            else
            {
                transform.position = Vector3.Lerp(transform.position, backDirection, Time.deltaTime * speed);
            }
        }
    }
}
