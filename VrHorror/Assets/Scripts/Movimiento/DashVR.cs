using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DashVR : MonoBehaviour {

    public SteamVR_Action_Boolean dash;

    public float distance, speed;
    public bool isMoving;
    
    public GameObject marker, marker2, go;
    public Transform pointer, parent;
    public LineRenderer ln;

    public RaycastHit hit;
    public Ray landingRay;
    
    
    // Use this for initialization
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Ray direction
        landingRay = new Ray(pointer.position, pointer.forward);
        Debug.DrawRay(transform.position, transform.forward * distance, Color.red);
        
        // Show Marker at direction
        if (Physics.Raycast(landingRay, out hit, distance))
        {
            Destroy(go); // destroy clones
            go = Instantiate(marker, hit.point, Quaternion.identity); // set marker 1
            go.transform.position = hit.point; // show marker at position
        }

        if (isMoving)
        {
            Move(marker2.transform.position);
        }
    }

    public void Move(Vector3 target)
    {
        float moving = speed * Time.deltaTime;
        parent.localPosition = Vector3.MoveTowards(new Vector3(parent.localPosition.x, 0, parent.localPosition.z), target, moving);
    }

    public void VRMethod()
    {
        if (dash.GetStateDown(SteamVR_Input_Sources.Any))
        {
            isMoving = true;
            Destroy(marker2); // destroy clones
            marker2 = Instantiate(marker2, hit.point, Quaternion.identity); // create marker2 at position
            marker2.transform.position = go.transform.position; // marker2 follow position
        }
    }
    
}
