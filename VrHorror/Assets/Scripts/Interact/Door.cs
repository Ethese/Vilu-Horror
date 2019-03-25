using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Door : MonoBehaviour
{
    public GameObject hand, limitA, limitB;
    public Transform joint;
    public Vector3 startingPos, limitPos;
    public Hand h;

    public float rotSpeed, rotMax, rotMin;
    public bool grabbed, limit, closed, ready;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPos = joint.position;
        grabbed = false;
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed && ready)
        {
            DoorRotation();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            grabbed = true;
            h = hand.GetComponent<Hand>();
        }

        if (other.gameObject.name == "LimitA")
        {
            Debug.Log("STOOOOP");
            //closed = true;
            ready = false;
        }

        if (other.gameObject.name == "LimitB")
        {
            limitPos = joint.position;
            ready = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand")
        {
            h = hand.GetComponent<Hand>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            grabbed = false;
            ready = true;
        }

        if (other.gameObject.name == "LimitB")
        {
            limit = false;
        }
    }


    public void DoorRotation()
    {
        if (h.pressing)
        {
            // Follow hand
            Vector3 dir = new Vector3((hand.transform.position.x - joint.position.x), 0, (hand.transform.position.z - joint.position.z));
            Quaternion rotation = Quaternion.LookRotation(dir);
            joint.rotation = Quaternion.Lerp(joint.rotation, rotation, rotSpeed);
        }
    }
}
