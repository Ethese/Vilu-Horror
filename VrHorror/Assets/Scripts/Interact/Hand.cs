using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour {

    public SteamVR_Action_Boolean grabbing = null;

    private SteamVR_Behaviour_Pose pose = null;
    private FixedJoint joint = null;
    private Interact current = null;
    private List<Interact> contacts = new List<Interact>();

    private void Awake()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        joint = GetComponent<FixedJoint>();
    }
    
	// Update is called once per frame
	void Update () {

        if (grabbing.GetStateDown(pose.inputSource))
        {
            PickUp();
        }

        if (grabbing.GetStateUp(pose.inputSource))
        {
            Drop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("ObjetoSuelto"))
        {
            return;
        }

        contacts.Add(other.gameObject.GetComponent<Interact>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("ObjetoSuelto"))
        {
            return;
        }

        contacts.Remove(other.gameObject.GetComponent<Interact>());
    }

    public void PickUp()
    {
        // get nearest
        current = GetNearest();

        // null check
        if (!current)
        {
            return;
        }

        // already held
        if (current.activeHand)
        {
            current.activeHand.Drop();
        }

        // position
        current.transform.position = transform.position;

        // attach
        Rigidbody target = current.GetComponent<Rigidbody>();
        joint.connectedBody = target;

        // set active hand
        current.activeHand = this;
    }

    public void Drop()
    {
        // nullcheck
        if (!current)
        {
            return;
        }

        // apply velocity
        Rigidbody target = current.GetComponent<Rigidbody>();
        target.velocity = pose.GetVelocity();
        target.angularVelocity = pose.GetAngularVelocity();

        // detach
        joint.connectedBody = null;

        // clear
        current.activeHand = null;
        current = null;

    }

    private Interact GetNearest()
    {
        Interact nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (Interact inter in contacts)
        {
            distance = (inter.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = inter;
            }
        }

        return nearest;
    }
}
