﻿using System.Collections;
using System.Collections.Generic;
//using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using Valve.VR;

public class Menu_Pausa : MonoBehaviour
{
    public SteamVR_Action_Boolean pausa;
    public static bool pausado=false;
    public GameObject Menu;
   

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (pausa.GetStateDown(SteamVR_Input_Sources.Any))
        {
            if (pausado)
            {
                VolverAlJuego();
            }
            else
            {
                   
                Pausa();
            }
        }
    }

    public void VolverAlJuego()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        //GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
        pausado = false;
    }

    public void Pausa()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        //GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        pausado = true;
        
    }
}
