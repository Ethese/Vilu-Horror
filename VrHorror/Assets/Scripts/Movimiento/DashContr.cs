using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DashContr : MonoBehaviour
{
    public SteamVR_Action_Boolean move = null;
    public SteamVR_Behaviour_Pose pose = null;

    public Body b;

    public float distance;
    public bool isMoving;

    public GameObject marker, marker2;

    [HideInInspector]
    public GameObject go, go2;

    public Transform pointer;
    private LineRenderer ln;

    public RaycastHit hit;
    public Ray landingRay;

    // Start is called before the first frame update
    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        ln = GetComponent<LineRenderer>();
        ln.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();

        if (ln.enabled)
        {
            SetLaser();
        }
    }

    public void SetLaser()
    {
        // Ray direction
        landingRay = new Ray(pointer.position, pointer.forward);

        // Show Marker at direction
        if (Physics.Raycast(landingRay, out hit, distance))
        {
            //Destroy(marker2); // Destroy previus marker2
            Destroy(go); // destroy clones
            go = Instantiate(marker, hit.point, Quaternion.identity); // set marker 1 at raycast hit point
            go.transform.position = hit.point; // marker1 follows raycast hit point position
        }
    }

    // sets cameraRig target position at marker2
    public Vector3 SetDirection()
    {
        Destroy(go2); // destroy clones
        go2 = Instantiate(marker2, hit.point, Quaternion.identity); // creates marker2 at raycast hit point
        return go2.transform.position;
    }

    // Pressing the move button
    public void ChangeState()
    {
        if (move.GetStateDown(pose.inputSource) || Input.GetKeyDown("space")) // pressed
        {
            ln.enabled = true;
        }

        if (move.GetStateUp(pose.inputSource) || Input.GetKeyUp("space")) // lifted
        {
            ln.enabled = false;
            SetDirection(); 
            isMoving = true;
        }
    }
}
