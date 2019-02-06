using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class Menu_Pausa : MonoBehaviour
{
    public static bool Pausado=false;
    public GameObject Menu;
   

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausado)
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
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
        Pausado = false;
    }

    public void Pausa()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        Pausado = true;
        
    }
}
