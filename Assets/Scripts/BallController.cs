using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private float m_Speed = 20f;
    private Vector3 m_Direction;
    private Vector3 m_NormalizedForce;
    private bool m_İsGoingLeft;


    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        CreateRandomDirection();
    }

    private void FixedUpdate()
    {
        m_Rigidbody.AddForce(m_NormalizedForce - m_Rigidbody.velocity, ForceMode.VelocityChange);
        Debug.Log(m_NormalizedForce - m_Rigidbody.velocity);
    }

    private void CreateRandomDirection()
    {
        float x = 0;
        float z = 0;
        if (SetRandomSide(m_İsGoingLeft))
        {
            x = Random.Range(-1f, 0);
            z = Random.Range(-0.3f, 0.3f);
        }
        else
        {
            x = Random.Range(1f, 0);
            z = Random.Range(-0.3f, 0.3f);
        }
        
        m_Direction = new Vector3(x,0,z);
        m_NormalizedForce = m_Direction.normalized * m_Speed;
        m_Rigidbody.AddForce(m_NormalizedForce);

    }

    private bool SetRandomSide(bool isGoingLeft)
    {
        isGoingLeft = (Random.value < 0.5f);

        return isGoingLeft;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LongWall"))
        {
            m_NormalizedForce.z = -m_NormalizedForce.z;
        }

        if (other.CompareTag("LeftPaddle") || other.CompareTag("RightPaddle"))
        {
            m_NormalizedForce.x = -m_NormalizedForce.x;
        }
    }
}
