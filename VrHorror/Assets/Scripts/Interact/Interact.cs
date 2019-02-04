using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class Interact : MonoBehaviour {

    [HideInInspector]
    public Hand activeHand = null;

    public bool examined;
    private TextMesh text;

    private void Start()
    {
        text = GetComponentInChildren<TextMesh>();

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

    public void Examine()
    {
        text.text = gameObject.name;
    }

}
