using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class StopDriving : MonoBehaviour
{
    public CarAIControl carAi;
    public GameObject RigDriving;
    public GameObject Rigstanding;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "car")
        {
            carAi.m_Driving = false;
            Debug.Log("choco");
            RigDriving.SetActive(false);
            Rigstanding.SetActive(true);
        }
    }
}
