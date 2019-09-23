using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCheck : MonoBehaviour
{
    public bool active = false;

    void Update()
    {
        CheckOn();
    }

    void CheckOn ()
    {
        if (GetComponent<BoxCollider>().enabled == true)
        {
            active = true;
        }

        else
        {
            active = false;
        }
    }
}
