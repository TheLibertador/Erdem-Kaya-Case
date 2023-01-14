using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private Rigidbody ball;

    private Rigidbody m_RigidBody;
    private float speed = 20f;


    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
        {
            if (transform.CompareTag("RightPaddle"))
            {
                if (this.ball.velocity.x > 0f)
                {
                    if (this.ball.position.z > transform.position.z) {
                        m_RigidBody.AddForce(Vector3.forward * speed);
                    } else if (ball.position.z < transform.position.z) {
                        m_RigidBody.AddForce(Vector3.back * speed);
                    }
                }
                
                else
                {
                    if (transform.position.z > 0f) {
                        m_RigidBody.AddForce(Vector3.back * speed);
                    } else if (transform.position.z < 0f) {
                        m_RigidBody.AddForce(Vector3.forward * speed);
                    }
                }
            }

            else if (transform.CompareTag("LeftPaddle"))
            {
                if (this.ball.velocity.x < 0f)
                {
                    if (this.ball.position.z > transform.position.z) {
                        m_RigidBody.AddForce(Vector3.forward * speed);
                    } else if (ball.position.z < transform.position.z) {
                        m_RigidBody.AddForce(Vector3.back * speed);
                    }
                }
                
                else
                {
                    if (transform.position.z > 0f) {
                        m_RigidBody.AddForce(Vector3.back * speed);
                    } else if (transform.position.z < 0f) {
                        m_RigidBody.AddForce(Vector3.forward * speed);
                    }
                }
            }
           
        }
}
