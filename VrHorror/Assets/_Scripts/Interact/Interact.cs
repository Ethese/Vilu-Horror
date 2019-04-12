using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class Interact : MonoBehaviour {

    [HideInInspector]
    public Hand activeHand = null;

    private Sound s;

    public bool examined, dropped, impact, touched;
    public float velocity;
    private TextMesh text;

    private void Start()
    {
        text = GetComponentInChildren<TextMesh>();
        s = GetComponent<Sound>();
        examined = false;
        text.text = string.Empty;
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

        if (impact)
        {
            s.Impact(velocity);
            impact = false;
        }
    }

    #region COLLISIONS
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            examined = true;
            touched = true;
        }

        if (examined && velocity > 0)
        {
            if (other.tag == "ENEMY")
            {
                Debug.Log("OUF");
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand")
        {
            examined = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            examined = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            impact = true;
        }
    }
    #endregion
    public void Examine()
    {
        text.text = gameObject.name; // show object STATS
    }

    public void GetVelocity(Vector3 vel)
    {
        velocity = vel.magnitude; // get velocity from hand velocity
    }
}
