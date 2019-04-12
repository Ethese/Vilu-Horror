using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public Checkpoint cp,cp1,cp2,cp3;

    public GameObject cinematicPl, player, light;

    public AudioSource car1, car2, rain;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 2;
    }

    // Update is called once per frame
    void Update()
    {
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
        }

        if (cp1.check || Input.GetKey("2"))
        {
            Phase2();
        }

        if (cp2.check || Input.GetKeyDown("3"))
        {
            Phase3();
        }

    }

    public void Timer()
    {
        time -= 1 * Time.deltaTime;

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
        rain.Stop();
    }

    public void Phase3()
    {
        light.transform.Rotate(-90,0,0);
    }
}
