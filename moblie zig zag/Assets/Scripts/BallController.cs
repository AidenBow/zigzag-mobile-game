using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    bool started;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent< Rigidbody > ();
    }
    void Start()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        } else
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
}
