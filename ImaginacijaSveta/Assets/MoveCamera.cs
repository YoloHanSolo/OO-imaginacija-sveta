﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject[] nodes;
    public GameObject[] look;
    public float speed;
    public float damping;
    public int size;
    int p = 0;

    void Start()
    {
        
    }

    void Update()
    {

        float step = speed * Time.deltaTime;

        maincamera.transform.position = Vector3.MoveTowards(maincamera.transform.position, new Vector3(nodes[p].transform.position.x, nodes[p].transform.position.y, nodes[p].transform.position.z), step);
        Quaternion rotation = Quaternion.LookRotation(look[p].transform.position - maincamera.transform.position);
        maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, rotation, Time.deltaTime * damping);

        if (Vector3.Distance(maincamera.transform.position, nodes[p].transform.position) < 0.001f)
        {
            p++;
            if( p >= size)
            {
                p = 0;
            }
        }
    }
}
