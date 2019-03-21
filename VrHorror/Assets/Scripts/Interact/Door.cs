using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Door : MonoBehaviour
{
    public GameObject hand;
    public Hand h;

    public float rotSpeed;
    public bool grabbed;
    
    // Start is called before the first frame update
    void Start()
    {
        h = hand.GetComponent<Hand>();
        grabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
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
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand")
        {
            grabbed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            grabbed = false;
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

}
