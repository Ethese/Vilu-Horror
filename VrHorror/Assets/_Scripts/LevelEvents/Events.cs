using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public Checkpoint cp,cp1,cp2,cp3;
    public GameObject cinematicPl, player, light, _object;

    public AudioSource car1, car2, rain, ost;
    public AudioClip ap;
    public ENEMY en;

    public float time, time2;
    public bool tc, osting;

    // Start is called before the first frame update
    void Start()
    {
        time = 2f;
        time2 = 0;
        osting = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        tc = _object.GetComponent<Interact>().touched;
        if (cinematicPl.activeSelf)
        {
            car1.Stop();
            Timer();
            if (time == 0)
            {
                player.SetActive(true);
                cinematicPl.SetActive(false);
            }
        }

        if (cp.check || Input.GetKey("1"))
        {
            Phase1();
            Debug.Log("Phase 1 Iniciated");
        }

        if (cp1.check || Input.GetKey("2"))
        {
            Phase2();
            Debug.Log("Phase 2 Iniciated");
        }

        if (cp2.check || Input.GetKeyDown("3"))
        {
            Phase3();
            Debug.Log("Phase 3 Iniciated");
        }

        if (tc || Input.GetKey("h"))
        {
            Timer2();
            Phase4();
            Debug.Log("Phase 4 Iniciated");
        }

        if (!osting)
        {
            Debug.Log("Soundtrack ON");
            ost.PlayOneShot(ap);
            osting = true;
        }
    }

    public void Timer()
    {
        time -= 1f * Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
        }
    }

    public void Timer2()
    {
        time2 += 1f * Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
        }
    }

    public void Phase1()
    {
        car2.Play();
    }

    public void Phase2()
    {
        if (time2 < 50.1f && time2 > 50f)
        {
            osting = false;
        }
    }

    public void Phase3()
    {
        light.transform.Rotate(-90,0,0);
        cp2.check = false;
    }

    public void Phase4()
    {
        en.chasing = true;
    }
}
