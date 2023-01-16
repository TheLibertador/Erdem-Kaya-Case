using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private Rigidbody ball;

    private Rigidbody m_RigidBody;
    private float speed = 50f;

    private int currentLevel;


    private void Start()
    {
        EventsManager.Instance.onGameFailed += StopPaddles;
        
        m_RigidBody = GetComponent<Rigidbody>();
        currentLevel = GameManager.Instance.level;
    }

    private void Update()
    {
        LeftPaddleMovement();
        RightPaddleMovement();
        IncreasePaddleSpeed();
    }

    private void LeftPaddleMovement()
    {
        if (transform.CompareTag("LeftPaddle"))
        {
            if (this.ball.velocity.x < 0f)
            {
                if (this.ball.position.z > transform.position.z) {
                    m_RigidBody.velocity = Vector3.forward * speed;
                } else if (ball.position.z < transform.position.z) {
                    m_RigidBody.velocity = Vector3.back * speed;
                }
            }
        }
    }

    private void RightPaddleMovement()
    {
        if (transform.CompareTag("RightPaddle"))
        {
            if (this.ball.velocity.x > 0f)
            {
                if (this.ball.position.z > transform.position.z) {
                    m_RigidBody.velocity = Vector3.forward * speed;
                } else if (ball.position.z < transform.position.z) {
                    m_RigidBody.velocity = Vector3.back * speed;
                }
            }
        }
    }
    
    private void IncreasePaddleSpeed()
    {
        if (GameManager.Instance.level > currentLevel)
        { 
            speed = speed + (GameManager.Instance.level * 2);
            currentLevel = GameManager.Instance.level;
        }
    }

    private void StopPaddles()
    {
        m_RigidBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
