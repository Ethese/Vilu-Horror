using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class Interact : MonoBehaviour {

    [HideInInspector]
    public Hand activeHand = null;

    private Sound s;

    public bool examined, dropped, impact;
    public float velocty;
    private TextMesh text;

    private void Start()
    {
        text = GetComponentInChildren<TextMesh>();
        s = GetComponent<Sound>();

        text.text = string.Empty;
        examined = false;
    }

    private void Update()
    {
        if (examined)
        {
            Examine();
        }
        else
        {
            text.text = string.Empty;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            examined = true;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "hand")
        {
            examined = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "hand")
        {
            examined = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            s.Impact(velocty); // on collision increase sound radius
        }
    }

    public void Examine()
    {
        text.text = gameObject.name; // show object STATS
    }

    public void GetVelocity(Vector3 vel)
    {
        velocty = vel.magnitude; // get velocity from hand velocity
    }

}
