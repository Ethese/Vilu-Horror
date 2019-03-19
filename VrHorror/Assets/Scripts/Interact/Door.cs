using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Door : MonoBehaviour
{
    public GameObject door;
    public Hand h;

    public bool grabbed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            h = other.gameObject.GetComponent<Hand>();

            if (h.grabbing.GetStateDown(h.pose.inputSource) || Input.GetKey("j"))
            {
                door.transform.LookAt(other.transform);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand")
        {
            h = other.gameObject.GetComponent<Hand>();

            if (h.grabbing.GetStateDown(h.pose.inputSource) || Input.GetKey("j"))
            {
                door.transform.LookAt(other.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

}
