using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallRaycaster : MonoBehaviour
{

    private LineRenderer forwardLine;
    private LineRenderer backwardLine;
    private Transform rightPaddle;
    private Transform leftPaddle;

    private void Start()
    {
        rightPaddle = GameObject.FindGameObjectWithTag("RightPaddle").transform;
        leftPaddle = GameObject.FindGameObjectWithTag("LeftPaddle").transform;
        forwardLine = transform.Find("ForwardLine").GetComponent<LineRenderer>();
        backwardLine = transform.Find("BackwardLine").GetComponent<LineRenderer>();
        
        forwardLine.enabled = true;
        backwardLine.enabled = true;
    }

        private void Update()
       {
           DrawLine();
           
           RaycastHit hit;
           RaycastHit hitBack;
           if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
           {
               
               if(hit.collider.CompareTag("Player"))
               {
                   Debug.Log("Hit " + hit.collider.name + " with tag " + "Player");
               }
           }
           if(Physics.Raycast(transform.position, -transform.forward, out hitBack, 100f))
           {
               backwardLine.SetPosition(0, transform.position);
               backwardLine.SetPosition(1, hitBack.point);
               if(hit.collider.CompareTag("Player"))
               {
                   Debug.Log("Hit " + hitBack.collider.name + " with tag " + "Player");
               }
           }   
       }

        private void DrawLine()
        {
            backwardLine.SetPosition(0, transform.position);
            backwardLine.SetPosition(1, new Vector3(rightPaddle.position.x, transform.position.y, transform.position.z));
            forwardLine.SetPosition(0, transform.position);
            forwardLine.SetPosition(1, new Vector3(rightPaddle.position.x,  transform.position.y, transform.position.z));
            
        }
}
