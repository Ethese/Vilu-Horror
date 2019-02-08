using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DashContr : MonoBehaviour
{
    public SteamVR_Action_Boolean move = null;

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
        if (move.GetStateDown(SteamVR_Input_Sources.Any))
        {
            SetLaser(true);
        }

        if (move.GetStateUp(SteamVR_Input_Sources.Any))
        {
            SetLaser(false);
            SetDirection(); 
            isMoving = true;
        }
    }
}
