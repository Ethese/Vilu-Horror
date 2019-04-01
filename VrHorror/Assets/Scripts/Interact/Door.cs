using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Door : MonoBehaviour
{
    public GameObject hand, limitA, limitB, door;
    public Transform pillar, joint;
    public Vector3 startingPos;
    public Hand handScript;
    public Quaternion mainYRotation;
    public HingeJoint hJoint;

    public float rotSpeed;
    public bool grabbed, ready;
    
    // Start is called before the first frame update
    void Start()
    {
        hJoint = transform.parent.GetComponent<HingeJoint>();
        startingPos = door.transform.localPosition;
        mainYRotation = door.transform.localRotation;
        grabbed = false;
        ready = true;
        door.transform.parent = pillar;
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
            handScript = hand.GetComponent<Hand>();
        }

        if (other.gameObject.name == "LimitA")
        {
            Debug.Log("STOOOOP");
            ready = false;
        }

        if (other.gameObject.name == "LimitB")
        {
            ready = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand")
        {
            handScript = hand.GetComponent<Hand>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            grabbed = false;
            ready = true;
            ResetDoor();
        }
    }
    
    public void DoorRotation()
    {
        if (handScript.pressing)
        {
            // Follow hand
            Vector3 dir = new Vector3((hand.transform.position.x - joint.position.x), 0, (hand.transform.position.z - joint.position.z));
            Quaternion rotation = Quaternion.LookRotation(dir);
            joint.rotation = Quaternion.Lerp(joint.rotation, rotation, rotSpeed);
        }

        door.transform.parent = joint;
        hJoint.connectedBody = null;
    }

    public void ResetDoor()
    {
        door.transform.parent = pillar;
        hJoint.connectedBody = joint.gameObject.GetComponent<Rigidbody>();
    }
}
