using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPlayer : MonoBehaviour
{
    Vector3 startPos, endPos, directionDistance;
    //float touchTimeStart, touchTimeFinish, timeInterval;

    [SerializeField]
    private Rigidbody2D rigidbody2D;

    public float throwspeed = 500f;

    private bool isJumping = false;
    private float timeSinceLastJump;

    void Update()
    {
        // Touchcount for mobile!
        if (Input.GetMouseButtonDown(0)) // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //touchTimeStart = Time.time;
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0)) // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            // Time mouse held down
            //touchTimeFinish = Time.time;
            //timeInterval = touchTimeFinish - touchTimeStart;

            // Endpos and direction
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            directionDistance = startPos - endPos;

            // Distance and speed calc
            //distance = Vector2.Distance(startPos, endPos);

            // Adding forces and make sure you can only jump once
            if (!isJumping)
            {
                isJumping = true;
                Vector2 directionVec = -directionDistance;
                Debug.Log(directionVec);
                rigidbody2D.AddForce(new Vector2(directionVec.x * throwspeed * Time.deltaTime, directionVec.y * throwspeed * Time.deltaTime));
            }
        }

        // Reset jump count
        if (isJumping)
        {
            timeSinceLastJump += Time.deltaTime;
            if (rigidbody2D.velocity == Vector2.zero && timeSinceLastJump > 1f)
            {
                timeSinceLastJump = 0f;
                isJumping = false;
            }
        }
    }
}