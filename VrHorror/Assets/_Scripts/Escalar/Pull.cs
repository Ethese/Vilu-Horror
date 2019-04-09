using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Pull : MonoBehaviour
{
    public GameObject parent;

    public SteamVR_Action_Boolean grabbing = null;
    public bool agarre;
    private SteamVR_Behaviour_Pose pose = null;

    public Vector3 posAnt;

    // Start is called before the first frame update
    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        posAnt = pose.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbing.GetStateDown(pose.inputSource))
        {
            parent.transform.position += (posAnt - pose.transform.localPosition);
        }

        posAnt = pose.transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        agarre = true;
    }

    private void OnTriggerStay(Collider other)
    {
        agarre = true;
    }

    private void OnTriggerExit(Collider other)
    {
        agarre = false;
    }
}
