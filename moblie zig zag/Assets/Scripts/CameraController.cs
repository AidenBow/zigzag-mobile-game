using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    Vector3 offset;
    public float lerpRate;
    public bool gameOver;
    void Start()
    {
        offset = ball.transform.position - transform.position; //distance between camera and ball
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position; //must be saved in temp variable
        Vector3 targetPos = ball.transform.position - offset;// offset taken away to keep camera at same height
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime); //save to temp cause you cant edit transform directly. Use deltatime to stop computer speed from influencing lerp speed
        transform.position = pos; 
    }
}
