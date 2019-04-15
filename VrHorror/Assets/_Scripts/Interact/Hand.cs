using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour {

    // VR Inputs
    public SteamVR_Action_Boolean grabbing = null;
    public SteamVR_Action_Boolean move = null;
    private SteamVR_Behaviour_Pose pose = null;

    // Interaction
    private FixedJoint joint = null;
    private Interact current = null;
    private List<Interact> contacts = new List<Interact>();

    // RayCast
    public RaycastHit hit;
    public Ray landingRay;
    private LineRenderer ln;

    // Reference
    public Hand otherHand;
    public Player pl;
    private Transform pointer;

    // Markers
    [HideInInspector]
    public GameObject go, go2;
    public GameObject marker, marker2;

    // parameters
    public float distance, handDistance, handSpeed;
    public bool pressing, isUsing;

    private void Awake()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        ln = GetComponent<LineRenderer>();
        joint = GetComponent<FixedJoint>();
        pointer = transform;
        ln.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();
        Interacted();

        if (ln.enabled)
        {
            SetLaser();
        }
    }

    private void FixedUpdate()
    {
        handDistance = Vector3.Distance(transform.position, otherHand.transform.position);
        handSpeed = pose.GetAngularVelocity().magnitude;
    }

    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("ObjetoSuelto"))
        {
            return;
        }
        contacts.Add(other.gameObject.GetComponent<Interact>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("ObjetoSuelto"))
        {
            return;
        }
        contacts.Remove(other.gameObject.GetComponent<Interact>());
    }
    #endregion

    #region Interact
    public void PickUp()
    {
        // get nearest
        current = GetNearest();

        // null check
        if (!current)
        {
            return;
        }

        // already held
        if (current.activeHand)
        {
            current.activeHand.Drop();
        }

        // position
        current.transform.position = transform.position;

        // attach
        Rigidbody target = current.GetComponent<Rigidbody>();
        joint.connectedBody = target;
        
        // set active hand
        current.activeHand = this;
    }

    public void Drop()
    {
        // nullcheck
        if (!current)
        {
            return;
        }

        // apply velocity
        Rigidbody target = current.GetComponent<Rigidbody>();
        target.velocity = pose.GetVelocity();
        target.angularVelocity = pose.GetAngularVelocity();

        // detach
        joint.connectedBody = null;

        // clear
        current.activeHand = null;
        current = null;
    }

    public void Interacted()
    {
        if (grabbing.GetStateDown(pose.inputSource) || Input.GetKeyDown("r"))
        {
            PickUp();
            pressing = true;
        }

        if (grabbing.GetStateUp(pose.inputSource) || Input.GetKeyUp("r"))
        {
            Drop();
            pressing = false;
        }
    }

    private Interact GetNearest()
    {
        Interact nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (Interact inter in contacts)
        {
            distance = (inter.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = inter;
            }
        }
        return nearest;
    }
    #endregion

    #region Movement
    public void SetLaser()
    {
        // Ray direction
        landingRay = new Ray(pointer.position, pointer.forward);

        // Show Marker at direction
        if (Physics.Raycast(landingRay, out hit, 20f))
        {
            Destroy(go); // destroy clones
            go = Instantiate(marker, hit.point, Quaternion.identity); // set marker 1 at raycast hit point
            go.transform.position = hit.point; // marker1 follows raycast hit point position
        }
        else
        {
            Destroy(go);
        }
    }

    // sets cameraRig target position at marker2
    public Vector3 SetDirection()
    {
        Destroy(go2);
        go2 = Instantiate(marker2, go.transform.position, Quaternion.identity); // creates marker2 at raycast hit point
        return go2.transform.position;
    }

    // Pressing the move button
    public void ChangeState()
    {
        if (move.GetStateDown(pose.inputSource) && !otherHand.isUsing || Input.GetKeyDown("space")) // pressed
        {
            ln.enabled = true;
            isUsing = true;
        }

        if (move.GetStateUp(pose.inputSource) || Input.GetKeyUp("space")) // lifted
        {
            SetDirection();
            pl.isMoving = true;
            ln.enabled = false;
            isUsing = false;
        }
    }
    #endregion

    #region Methods
    #endregion
}
