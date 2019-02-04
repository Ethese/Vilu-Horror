using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MovementTouchpad : MonoBehaviour
{
    [SteamVR_DefaultAction("MoveTouchpad")]
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
        movimiento = SteamVR_Input._default.inActions.MoveTouchpad.GetAxis(SteamVR_Input_Sources.Any);
        cameraRig.position += (transform.right * movimiento.x + transform.forward * movimiento.y) * Time.deltaTime * speed;
        cameraRig.position = new Vector3(cameraRig.position.x, cameraRig.position.y, cameraRig.position.z);
    }
}