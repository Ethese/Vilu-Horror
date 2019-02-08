using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Linterna : MonoBehaviour
{
    public SteamVR_Action_Single squeeze;
    public GameObject linterna;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (squeeze.GetAxis(SteamVR_Input_Sources.Any) > 0)
        {
            Debug.Log("prende");
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
