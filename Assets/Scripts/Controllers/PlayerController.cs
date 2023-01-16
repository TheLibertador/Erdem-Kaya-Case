using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private float speed = 10f;
    private float jumpForce = 10f;
    private bool isGrounded;
    
    [SerializeField] private DynamicJoystick joystick;
    
    

    private void Start()
    {
        EventsManager.Instance.onGameFailed += KillPLayer;
        
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
       Move();

       if (Input.GetKey(KeyCode.A))
       {
           Jump();
       }
    }

    private void Move()
    {
        m_Rigidbody.velocity =
            new Vector3(joystick.Horizontal * speed, m_Rigidbody.velocity.y, joystick.Vertical * speed);
    }

    public void Jump()
    {
        if (CheckIsGrounded())
        {
            m_Rigidbody.AddForce(new Vector3(0, jumpForce,0 ), ForceMode.Impulse);
        }
       
    }

    private bool CheckIsGrounded()
    {
        if (transform.position.y > 2.5f)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }

        return isGrounded;
    }

    private void KillPLayer()
    {
        Destroy(gameObject);
    }
}
