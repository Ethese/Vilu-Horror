using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCurve : MonoBehaviour
{
    public int killAfter, velocity;
    public bool reflect;
    
    // Update is called once per frame
    void Update()
    {
        GravCast(this.transform.position, Vector3.right);
    }

    Vector3[] GravCast(Vector3 startPos, Vector3 direction)
    {
        RaycastHit hit;
        Vector3[] vectors = new Vector3[killAfter];
        Ray ray = new Ray(startPos, direction);
        for (int i = 0; i < killAfter; i++)
        {
            if (Physics.Raycast(ray, out hit, 1f))
            {
                if (reflect)
                {
                    print(hit.normal);
                    /*for (int e = 0; e < killAfter; e++)
                    {
                        if (Physics.Raycast(ray, out hit, 1f))
                        {
                            return vectors;
                        }
                        ray = new Ray(ray.origin + ray.direction, ray.direction + (Physics.gravity / killAfter / velocity));
                    }*/
                }
                return vectors;
            }
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            ray = new Ray(ray.origin + ray.direction, ray.direction + (Physics.gravity / killAfter / velocity));
            vectors[i] = ray.origin;

        }
        return vectors;
    }
}

