using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionState
{
    Idle, Ready, Action, Finish
}

public class StateManager : MonoBehaviour
{
    public GameObject objectLeft;
    public GameObject objectRight;

    public GameObject objectBefore;
    public GameObject objectAfter;

    public ActionState state = ActionState.Idle;

    void Update()
    {
        switch (state)
        {
            case ActionState.Idle:
                if (objectLeft.GetComponent<EventTrigger>().eventTrigger == true && objectRight.GetComponent<EventTrigger>().eventTrigger == true )
                {
                    StartCoroutine(ChangeDelay());
                }
            break;

            case ActionState.Ready:
                if (objectBefore.activeSelf == true)
                {
                    state = ActionState.Action;
                }
            break;

            case ActionState.Action:
                if (objectAfter.activeSelf == true)
                {
                    state = ActionState.Finish;
                }
            break;

            case ActionState.Finish:
                {
                    state = ActionState.Action;
                }
            break;
        }
    }

    IEnumerator ChangeDelay()
    {
        yield return new WaitForSeconds(1f);

        state = ActionState.Ready;
    }
}
