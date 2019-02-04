using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MovementTouchpad : MonoBehaviour
{
    //[SteamVR_DefaultAction("MoveTouchpad")]
    public float speed;
    private Vector2 movimiento = Vector2.zero;
    public Transform cameraRig;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //cameraRig.transform.eulerAngles = new Vector3(0, rotation, 0);
        //movimiento = SteamVR_Input._default.inActions.MoveTouchpad.GetAxis(SteamVR_Input_Sources.Any);
        //cameraRig.transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        //rb.MovePosition(transform.position + (transform.right * movimiento.x * speed) + (transform.forward * movimiento.y * speed));
        cameraRig.position += (transform.right * movimiento.x + transform.forward * movimiento.y) * Time.deltaTime * speed;
        cameraRig.position = new Vector3(cameraRig.position.x, cameraRig.position.y, cameraRig.position.z);
    }
}