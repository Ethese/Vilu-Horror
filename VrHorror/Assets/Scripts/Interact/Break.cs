using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject c1, c2, c3, c4;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "floor")
        {
            c1.transform.parent = null;
            c2.transform.parent = null;
            c3.transform.parent = null;
            c4.transform.parent = null;
            


        }
    }
}
