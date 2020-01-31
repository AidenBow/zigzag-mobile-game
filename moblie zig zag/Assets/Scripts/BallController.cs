using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject particle;

    [SerializeField]
    private float speed;
    bool started;
    bool gameOver;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent< Rigidbody > ();
    }
    void Start()
    {
        rb.velocity = new Vector3(0, 0, 0);
        started = false;
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
        Debug.DrawRay(transform.position, Vector3.down, Color.blue);
        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            Camera.main.GetComponent<CameraController>().gameOver = true;

            rb.velocity = new Vector3(0, -25f, 0);
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(part, 1);
        }
    }
}
