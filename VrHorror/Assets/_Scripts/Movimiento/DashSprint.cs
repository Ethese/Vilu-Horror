using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DashSprint : MonoBehaviour
{
    public bool leftReady, rightReady, run;

    public SteamVR_Behaviour_Pose leftPose = null;
    public SteamVR_Behaviour_Pose rightPose = null;

    public float l, r;

    // Start is called before the first frame update
    void Start()
    {
        leftReady = false;
        rightReady = false;
        run = false;
    }

    // Update is called once per frame
    void Update()
    {
        l = leftPose.GetAngularVelocity().magnitude;
        r = rightPose.GetAngularVelocity().magnitude;

        GetReadyToRumble();

        if (leftReady && rightReady)
        {
            run = true;
        }
        else
        {
            run = false;
        }
    }

    public void GetReadyToRumble()
    {
        if (leftPose.GetAngularVelocity().z > 1.5f || leftPose.GetAngularVelocity().z < -1.5f)
        {
            if (l > 1.5f)
            {
                leftReady = true;
            }
        }

        if (rightPose.GetAngularVelocity().z > 1.5f || rightPose.GetAngularVelocity().z < -1.5f)
        {
            if (r > 1.5f)
            {
                rightReady = true;
            }
        }
    }
}
