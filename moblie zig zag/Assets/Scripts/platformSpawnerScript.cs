using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawnerScript : MonoBehaviour
{
    public GameObject platform;
    Vector3 lastPos;
    float size;
    public bool gameOver;
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        //for (int i = 0; i < 30; i++)
        //{
        //    SpawnRandom();
        //}

        InvokeRepeating("SpawnRandom",0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke("");
        }
    }

    void SpawnRandom()
    {
        int rand = Random.Range(0, 3);
        if (rand == 1)
        {
            SpawnX();
        } else
        {
            SpawnZ();
        }

    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
    }
}
