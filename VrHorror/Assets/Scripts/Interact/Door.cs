using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Door : MonoBehaviour
{
    public GameObject door;
    public Hand h;
    
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
            Debug.Log("touching");

            if (h.pressing || Input.GetKey("space"))
            {
                door.transform.LookAt(other.transform);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand")
        {

            if (h.pressing)
            {
                door.transform.LookAt(other.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

}
