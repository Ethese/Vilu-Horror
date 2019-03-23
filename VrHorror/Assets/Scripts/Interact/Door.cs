using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Door : MonoBehaviour
{
    public GameObject hand, limitA, limitB;
    public Hand h;

    public float rotSpeed, rotMax, rotMin, rotationY;
    public float y;
    public bool grabbed, limit;
    
    // Start is called before the first frame update
    void Start()
    {
        h = hand.GetComponent<Hand>();
        grabbed = false;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed && !limit)
        {
            DoorRotation();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            grabbed = true;
        }

        if (other.gameObject.name == "LimitA")
        {
            Debug.Log("STOOOOP");
            limit = true;
            y = -1;
        }

        if (other.gameObject.name == "LimitB")
        {
            limit = true;
            y = 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand")
        {
            //grabbed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            grabbed = false;
        }

        if (other.gameObject.name == "LimitB")
        {
            limit = false;
            y = 0;
        }
    }


    public void DoorRotation()
    {
        if (h.pressing)
        {
            // Follow hand
            Vector3 dir = new Vector3((hand.transform.position.x - transform.position.x), 0, (hand.transform.position.z - transform.position.z));
            Quaternion rotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSpeed);
        }
    }

    public void Clamp()
    {
        if (limit)
        {
            transform.Rotate(Vector3.up, (y * rotSpeed) * Time.deltaTime);
        }
    }

}
