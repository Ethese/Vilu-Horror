using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clima : MonoBehaviour
{
    GameObject [] splashFind;
    GameObject [] lluviaFind;
    public Light luz;
    public int rango;

    public Material[] skyboxes;

   public void RandomClima()
    {
        rango = Random.Range(0,3);
    }
   
    void ChangeMySkybox()
    {
        RenderSettings.skybox = skyboxes[rango];
    }

    void Start()
    {
        
        //splashFind = GameObject.FindGameObjectsWithTag("Splash");
        lluviaFind = GameObject.FindGameObjectsWithTag("Lluvia");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RandomClima();
            if (rango==0)
            {
                Despejado();
            }else if (rango == 1)
            {
                Despejado();
            }
            else if (rango == 2)
            {
                Lluvia();
            }
        }   
    }
    void Lluvia()
    {
        ChangeMySkybox();
        //Iniciar Lluvia
        foreach (GameObject lluvia in lluviaFind)
        {
            luz.intensity = 0.44f;
            lluvia.SetActive(true);
            //foreach (GameObject splash in splashFind)

            //{
             //   splash.SetActive(true);
            //}
        }
       
        Debug.Log("Lloviendo");
    }
    void Despejado()
    {
        ChangeMySkybox();
        //Detener Lluvia
        foreach (GameObject lluvia in lluviaFind)
        {
            luz.intensity = 1.4f;
            lluvia.SetActive(false);
            //foreach (GameObject splash in splashFind)
            //{
            //    splash.SetActive(false);
            //}
            
        }
        Debug.Log("No Lloviendo");
    }

}
