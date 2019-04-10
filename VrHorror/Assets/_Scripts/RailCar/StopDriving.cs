using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class StopDriving : MonoBehaviour
{
    public CarAIControl carAi;
    public GameObject RigDriving;
    public GameObject Rigstanding;
    public Animator anim;
    public Animator anim2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "car")
        {
            carAi.m_Driving = false;
            Debug.Log("choco");
            RigDriving.SetActive(false);
            Rigstanding.SetActive(true);
            StartCoroutine(Bajarse1());
            Debug.Log("asd");
        }
    }

    IEnumerator Bajarse1()
    {
        //This is a coroutine
        anim.SetTrigger("FadeOut");
        Debug.Log("Inicio");

        yield return new WaitForSeconds(3f);    //Wait one frame
        StartCoroutine(Bajarse2());

        Debug.Log("End Wait() function and the time is: " + Time.time);
    }
    IEnumerator Bajarse2()
    {
        //This is a coroutine
        anim2.SetTrigger("FadeIn");
        Debug.Log("Inicio");

        yield return new WaitForSeconds(3f);    //Wait one frame


        Debug.Log("End Wait() function and the time is: " + Time.time);
    }
}
