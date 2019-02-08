using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Linterna : MonoBehaviour
{
    public GameObject linterna;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("14"))
        {
            encender();
        }
    }

    void encender()
    {
        linterna.SetActive(true);
    }

    void apagar()
    {
        linterna.SetActive(false);
    }
}
