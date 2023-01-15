using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallRaycaster : MonoBehaviour
{

    private LineRenderer forwardLine;
    private LineRenderer backwardLine;
    

    private void Start()
    {
        forwardLine = transform.Find("ForwardLine").GetComponent<LineRenderer>();
        backwardLine = transform.Find("BackwardLine").GetComponent<LineRenderer>();
        
        Debug.Log(backwardLine.name);
    }

        private void Update()
       {
           
           RaycastHit hit;
           RaycastHit hitBack;
           if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
           {
               forwardLine.SetPosition(0, transform.position);
               forwardLine.SetPosition(1, hit.point);
               
               forwardLine.enabled = true;
               if(hit.collider.CompareTag("Player"))
               {
                   Debug.Log("Hit " + hit.collider.name + " with tag " + "Player");
               }
           }
           if(Physics.Raycast(transform.position, -transform.forward, out hitBack, 100f))
           {
               backwardLine.SetPosition(0, transform.position);
               backwardLine.SetPosition(1, hitBack.point);
               
               backwardLine.enabled = true;
               if(hit.collider.CompareTag("Player"))
               {
                   Debug.Log("Hit " + hitBack.collider.name + " with tag " + "Player");
               }
           }   
       }
}
