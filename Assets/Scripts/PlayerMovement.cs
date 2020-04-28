using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    float timeToRunFast = 8f;
    float recoverSpeed = 0.1f;
    float max_speed = 2f;
    float min_speed = 0.5f;
    float alpha;
    float speed;
    float m_Timer;

    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        //Speed caculation

        if (isWalking)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= timeToRunFast)
            {
                m_Timer = timeToRunFast;
            }
        }
        else
        {
            m_Timer -= recoverSpeed;
            if (m_Timer <= 0)
            {
                m_Timer = 0;
            }
        }
        alpha = m_Timer / timeToRunFast;
        speed = (1.0f - alpha) * max_speed + alpha * min_speed;

    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * speed);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
