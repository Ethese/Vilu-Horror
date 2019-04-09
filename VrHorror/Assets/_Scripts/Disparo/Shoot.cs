using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    GameObject prefab;//proyectil
    public Camera camara;
    public int barril=0;
    public int municion = 0;
    public int limite = 0;
   
    void Start()
    {
        prefab = Resources.Load("Projectile") as GameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        Disparo();
        Recarga();
    }

    void Disparo()
    {
        if (Input.GetMouseButtonDown(0) && barril>0)
        {
            barril--;
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position + camara.transform.forward * 2;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = camara.transform.forward * 10;
            // Debug.Log("Contador de Munición: " + GameVariables.municion);
        }
        else
        {
            Debug.Log("No hay balas");
        }
    }


    void Recarga()
    {
        if (Input.GetKeyDown("r") && barril==0 && municion>0)
        { 
            if (municion<=limite)
            {
                barril = barril + municion;
                municion = 0;
            }
            else
            {
                municion = municion - limite;
                barril = barril + limite;
            }
        }else{
            Debug.Log("No hay balas");
        }
    }

}
