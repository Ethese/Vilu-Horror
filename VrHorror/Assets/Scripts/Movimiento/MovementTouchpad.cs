using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MovementTouchpad : MonoBehaviour
{
    //[SteamVR_DefaultAction("MoveTouchpad")]
    public SteamVR_Action_Vector2 touchpd;
    public float speed;
    private Vector2 movimiento = Vector2.zero;
    public Transform cameraRig;

    public AudioSource sonido_pasos;

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
        movimiento = touchpd.GetAxis(SteamVR_Input_Sources.Any);
        cameraRig.position += (transform.right * movimiento.x + transform.forward * movimiento.y) * Time.deltaTime * speed;
        cameraRig.position = new Vector3(cameraRig.position.x, cameraRig.position.y, cameraRig.position.z);
        if (touchpd.GetAxis(SteamVR_Input_Sources.Any).x != 0 || touchpd.GetAxis(SteamVR_Input_Sources.Any).y != 0)
        {
            sonido_pasos.volume = 0.5f;
        }
        else
        {
            sonido_pasos.volume = 0.0f;
        }
    }
}