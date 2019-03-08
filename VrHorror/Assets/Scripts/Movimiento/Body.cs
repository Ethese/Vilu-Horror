﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public DashContr dc;
    public Sound stealth;
    public DashSprint ds;

    public Transform parent;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        dc.isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dc.isMoving)
        {
            stealth.Moving(speed * 1.5f);
            Move(dc.SetDirection());
        }
        else
        {
            stealth.Still();
        }

        if (ds.run)
        {
            speed = speed * 3;
        }
        else
        {
            speed = 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "STAHP")
        {
            dc.isMoving = false;
            Destroy(dc.go2); // destroy marker2 at collision
        }
    }

    public void Move(Vector3 target)
    {
        float moving = speed * Time.deltaTime;
        parent.localPosition = Vector3.MoveTowards(new Vector3(parent.localPosition.x, parent.localPosition.y, parent.localPosition.z), target, moving);
    }

}
