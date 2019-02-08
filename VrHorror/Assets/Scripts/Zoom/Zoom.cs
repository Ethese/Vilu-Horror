using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public int zoom = 20; //que sean valores numericos decimales para el fov de la camara
    public int FOVnormal = 60;//Por defecto
    public float suavizado = 2f;
    private bool isZoomed = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = !isZoomed;
        }

        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * suavizado);
        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, FOVnormal, Time.deltaTime * suavizado);

        }
    }
}
