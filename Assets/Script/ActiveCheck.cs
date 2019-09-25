using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCheck : MonoBehaviour
{
    public bool activeCheck = false;

    void Update()
    {
        if (GetComponent<BoxCollider>().enabled == true)
        {
            activeCheck = true;
        }

        else
        {
            activeCheck = false;
        }
    }
}
