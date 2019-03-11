using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float defaultLength = 5.0f;
    public GameObject punto;
    //public VRInputModule inputModule; 

    private LineRenderer lineRenderer = null;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    void Update()
    {
        updateLine();
    }

    private void updateLine()
    {
        float targetLength = defaultLength;

        //Raycast
        RaycastHit hit = CreateRaycast(targetLength);

        //Defautl
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        //Or based on hit
        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        // Set position of the dot 
        punto.transform.position = endPosition;

        //Set LinerRenderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }
}
