using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveManager : MonoBehaviour
{
    //public BoxCollider triggerLeft1;
    public ActiveCheck triggerCore1;
    public ActiveCheck triggerRight1;
    public int count = 0;

    void Update()
    {
        bool[] active = new bool[2];

        active[0] = triggerCore1.active;
        active[1] = triggerRight1.active;

        if (active[0] == true && active[1] == true)
        {
            count = 1;
        }

        else
        {
            count = 0;
        }
    }
}
