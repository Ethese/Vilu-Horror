using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Transition : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public TextMesh txt;

    public SteamVR_Action_Boolean grabbing = null;

    private Transform player;

    public bool touch;

    // Start is called before the first frame update
    void Start()
    {
        touch = false;
        txt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (touch)
        {
            if (grabbing.GetStateDown(SteamVR_Input_Sources.Any))
            {
                Move(player);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            touch = true;
            player.position = other.transform.position;
            txt.text = "GO?";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            touch = true;
            player.position = other.transform.position;
            txt.text = "GO?";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            touch = false;
            player.position = new Vector3();
            txt.text = "";
        }
    }

    public void Move(Transform player)
    {
        
    }

}
