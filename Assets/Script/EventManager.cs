using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject stateManager;

    public GameObject objectLeft;
    public GameObject objectRight;
    public GameObject objectCore;
    public GameObject objectBefore;
    public GameObject objectAfter;
    public GameObject triggerLeft;
    public GameObject triggerRight;
    public GameObject positionLeft;
    public GameObject positionRight;
    public GameObject targetLeft;
    public GameObject targetRight;
    
    public MeshRenderer meshRenderer;
    public Material[] mat;

    public float speed;
    public ActionState eventState = ActionState.Ready;

    int count = 0;




    private void Update()
    {
        switch (eventState)
        {
            case ActionState.Idle:
                count = 0;
                if (triggerLeft.GetComponent<ContactTrigger>().contactTrigger == false)
                {
                    objectLeft.transform.position = Vector3.Lerp(objectLeft.transform.position, positionLeft.transform.position, Time.deltaTime * speed);
                }

                if (triggerRight.GetComponent<ContactTrigger>().contactTrigger == false)
                {
                    objectRight.transform.position = Vector3.Lerp(objectRight.transform.position, positionRight.transform.position, Time.deltaTime * speed);
                }

                if(triggerLeft.GetComponent<ContactTrigger>().contactTrigger == true && triggerRight.GetComponent<ContactTrigger>().contactTrigger == true)
                {
                    eventState = ActionState.Ready;
                }
            break;

            case ActionState.Ready:
                if(eventState == stateManager.GetComponent<StateManager>().state)
                {
                    objectLeft.SetActive(false);
                    objectRight.SetActive(false);
                    objectCore.SetActive(false);

                    objectLeft.transform.position = targetLeft.transform.position;
                    objectRight.transform.position = targetRight.transform.position;

                    objectBefore.SetActive(true);
                    meshRenderer.material = mat[1];

                    eventState = ActionState.Action;
                }
            break;

            case ActionState.Action:
                if (eventState == stateManager.GetComponent<StateManager>().state)
                {
                    if (count == 0)
                    {
                        if (triggerLeft.GetComponent<ActiveCheck>().activeCheck == false && triggerRight.GetComponent<ActiveCheck>().activeCheck == false)
                        {
                            objectLeft.transform.position = targetLeft.transform.position;
                            objectRight.transform.position = targetRight.transform.position;

                            count = 1;
                        }
                    }

                    if (count == 1)
                    {
                        objectBefore.transform.Rotate(0, 30 * Time.deltaTime, 0);

                        if (triggerLeft.GetComponent<ActiveCheck>().activeCheck == true || triggerRight.GetComponent<ActiveCheck>().activeCheck == true)
                        {
                            objectRight.transform.position = targetRight.transform.position;
                            objectLeft.transform.position = targetLeft.transform.position;

                            objectBefore.SetActive(false);
                            objectLeft.SetActive(true);
                            objectRight.SetActive(true);
                            objectCore.SetActive(true);
                            meshRenderer.material = mat[0];

                            eventState = ActionState.Idle;
                        }

                        StartCoroutine(MoveCheckAction());

                        //if (triggerLeft.GetComponent<ContactTrigger>().contactTrigger == false && triggerLeft.GetComponent<ActiveCheck>().activeCheck == true)
                        //{
                        //    objectBefore.SetActive(false);
                        //    objectLeft.SetActive(true);
                        //    objectRight.SetActive(true);
                        //    objectCore.SetActive(true);
                        //    meshRenderer.material = mat[0];

                        //    objectLeft.transform.position = Vector3.Lerp(objectLeft.transform.position, positionLeft.transform.position, Time.deltaTime * speed);

                        //    if (objectRight.transform.position == targetRight.transform.position)
                        //    {
                        //        if (objectLeft.transform.position. != targetLeft.transform.position)
                        //            objectRight.transform.position = targetRight.transform.position;
                        //    }
                        //    else
                        //    {

                        //    }
                        //}

                        //if (triggerRight.GetComponent<ContactTrigger>().contactTrigger == false && triggerRight.GetComponent<ActiveCheck>().activeCheck == true)
                        //{
                        //    objectLeft.SetActive(true);
                        //    objectRight.SetActive(true);
                        //    objectCore.SetActive(true);
                        //    objectBefore.SetActive(false);
                        //    meshRenderer.material = mat[0];

                        //    objectRight.transform.position = Vector3.Lerp(objectRight.transform.position, positionRight.transform.position, Time.deltaTime * speed);

                        //    if (objectLeft.GetComponent<EventTrigger>().eventTrigger == false)
                        //    {
                        //        objectLeft.transform.position = targetLeft.transform.position;
                        //    }
                    }
                }
            break;

            case ActionState.Finish:
                if(eventState == stateManager.GetComponent<StateManager>().state)
                {
                    StartCoroutine(MoveCheckFinish());
                }
            break;
        }
    }

    IEnumerator MoveCheckAction()
    {
        float move1 = objectBefore.transform.position.x;
        yield return new WaitForSeconds(0.6f);

        float move2 = objectBefore.transform.position.x;
        yield return new WaitForSeconds(0.6f);

        float move3 = objectBefore.transform.position.x;
        yield return new WaitForSeconds(0.6f);

        float dis1 = move2 - move1;
        float dis2 = move3 - move2;

        if (Mathf.Sign(dis1) != Mathf.Sign(dis2) && dis1 > 15)
        {
            objectBefore.SetActive(false);
            objectAfter.SetActive(true);
            meshRenderer.material = mat[2];

            eventState = ActionState.Finish;
        }
    }

    IEnumerator MoveCheckFinish()
    {
        float move1 = objectAfter.transform.position.x;
        yield return new WaitForSeconds(0.6f);

        float move2 = objectAfter.transform.position.x;
        yield return new WaitForSeconds(0.6f);

        float move3 = objectAfter.transform.position.x;
        yield return new WaitForSeconds(0.6f);

        float dis1 = move2 - move1;
        float dis2 = move3 - move2;

        if (Mathf.Sign(dis1) != Mathf.Sign(dis2) && dis1 > 15)
        {
            objectBefore.SetActive(true);
            meshRenderer.material = mat[1];
            objectAfter.SetActive(false);

            eventState = ActionState.Action;
        }
    }
}
