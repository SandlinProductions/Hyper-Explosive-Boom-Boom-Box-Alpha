using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeMover : MonoBehaviour
{
    //This script is for anything we want to move from one point to other point
    public Transform moivPoint;
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float moveSpeed;
    public bool needsToMove;
    public GameObject thingNeedingToMove;
   

    void Start()
    {
        thingNeedingToMove = this.gameObject;
        startPoint = transform.position;
        endPoint = moivPoint.transform.position;
    }

    void FixedUpdate()
    {
        if(thingNeedingToMove.transform.position == startPoint)
        {
            needsToMove = true;
        }
        if (needsToMove == true)
        {
            MoveThatBitch();
            print("I need to move");
        }
    }
    void MoveThatBitch()
    {
        transform.position = Vector3.MoveTowards(transform.position, moivPoint.position, moveSpeed * Time.deltaTime);
        print("I'm Moving");
        if (thingNeedingToMove.transform.position == endPoint)
        {
            needsToMove = false;
            print("I've stoped");
        }
    }
}

