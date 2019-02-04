using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DashVR : MonoBehaviour {
    
    [SteamVR_DefaultAction("Teleport")]
    public float distance, dashDistance;
    public Transform pointer;
    public Transform parent;
    public bool isMoving;
    public float speed;
    public RaycastHit hit;
    public Ray landingRay;
    public GameObject marker, marker2;
    public Animator an;
    private GameObject go;
    private LineRenderer ln;

    // Use this for initialization
    void Start()
    {
        isMoving = false;
        ln = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ray direction
        landingRay = new Ray(pointer.position, pointer.forward);
        Debug.DrawRay(transform.position, transform.forward * distance, Color.red);

        // Move when triggered
        VRMethod();

        // Show Marker at direction
        if (Physics.Raycast(landingRay, out hit, distance))
        {
            Destroy(go); // destroy clones
            go = Instantiate(marker, hit.point, Quaternion.identity); // set marker 1
            go.transform.position = hit.point;
        }

        if (isMoving)
        {
            Move(marker2.transform.position);
            //an.SetBool("walking", true);
            //an.Play("Camera_Walk");
        }
        else
        {
            //an.SetBool("walking",false);
        }
    }

    public void Move(Vector3 target)
    {
        float moving = speed * Time.deltaTime;
        parent.localPosition = Vector3.MoveTowards(new Vector3(parent.localPosition.x, 0, parent.localPosition.z), target, moving);
        dashDistance = Vector3.Distance(new Vector3(parent.localPosition.x, 0, parent.localPosition.z), target);
        if (Vector3.Distance(new Vector3(parent.localPosition.x, 0, parent.localPosition.z), target) <= 2.5f)
        {
            isMoving = false;
        }
    }

    public void VRMethod()
    {
        if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.Any))
        {
            isMoving = true;
            Destroy(marker2);
            marker2 = Instantiate(marker2, hit.point, Quaternion.identity);
            marker2.transform.position = go.transform.position;
        }
    }
    
}
