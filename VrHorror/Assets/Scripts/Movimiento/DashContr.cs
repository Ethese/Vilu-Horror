using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DashContr : MonoBehaviour
{
    public SteamVR_Action_Boolean move = null;
    private SteamVR_Behaviour_Pose pose = null;

    public Body b;

    public float distance;
    public bool isMoving;

    public GameObject marker, marker2;
    private GameObject go;

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
    }

    public void SetLaser(bool enabled)
    {
        // enable/disable LASER
        ln.enabled = enabled;

        if (ln.enabled)
        {
            // Ray direction
            landingRay = new Ray(pointer.position, pointer.forward);
            Debug.DrawRay(transform.position, transform.forward * distance, Color.red);
        }

        // Show Marker at direction
        if (Physics.Raycast(landingRay, out hit, distance))
        {
            //Destroy(marker2); // Destroy previus marker2
            Destroy(go); // destroy clones
            go = Instantiate(marker, hit.point, Quaternion.identity); // set marker 1
            go.transform.position = hit.point;
        }
    }

    public Vector3 SetDirection()
    {
        Destroy(marker2);
        marker2 = Instantiate(marker2, hit.point, Quaternion.identity);
        marker2.transform.position = go.transform.position;

        return marker2.transform.position;
    }

    public void ChangeState()
    {
        if (move.GetStateDown(pose.inputSource))
        {
            SetLaser(true);
        }

        if (move.GetStateUp(pose.inputSource))
        {
            SetLaser(false);
            SetDirection(); 
            isMoving = true;
        }
    }
}
