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
    private Vector3 normalizedForce;
    private bool m_İsGoingLeft;


    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        CreateRandomDirection();
    }

    private void FixedUpdate()
    {
        m_Rigidbody.AddForce(normalizedForce - m_Rigidbody.velocity, ForceMode.VelocityChange);
        Debug.Log(normalizedForce - m_Rigidbody.velocity);
    }

    private void CreateRandomDirection()
    {
        float x = 0;
        float z = 0;
        if (SetRandomSide(m_İsGoingLeft))
        {
            x = Random.Range(-1f, 0);
            z = Random.Range(-0.5f, 0.5f);
        }
        else
        {
            x = Random.Range(1f, 0);
            z = Random.Range(-0.5f, 0.5f);
        }
        
        m_Direction = new Vector3(x,0,z);
        normalizedForce = m_Direction.normalized * m_Speed;
        m_Rigidbody.AddForce(normalizedForce);

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
            normalizedForce.z = -normalizedForce.z;
        }

        if (other.CompareTag("Paddle") || other.CompareTag("ShortWall"))
        {
            normalizedForce.x = -normalizedForce.x;
        }
    }
}
