using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Door : MonoBehaviour
{
    private Hand handScript;

    public Transform joint;
    private GameObject hand;

    public bool pressing;

    public float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        pressing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressing)
        {
            DoorRotation();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            pressing = true;
            handScript = other.GetComponent<Hand>();
            hand = other.gameObject;
            Debug.Log("contacto");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            pressing = false;
            handScript = null;
            hand = null;
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

        //door.transform.parent = joint;
        //hJoint.connectedBody = null;
    }
}
