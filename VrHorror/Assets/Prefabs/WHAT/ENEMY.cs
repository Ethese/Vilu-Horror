using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY : MonoBehaviour
{
    public bool chasing, shout, shout2, shout3;
    public float speed;
    public float time;

    public AudioSource ad;
    public AudioClip ac, ac1, ac2;
    public Transform pl;
    public Animator an;

    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
        ad = GetComponent<AudioSource>();
        shout = true;
        shout2 = true;
        shout3 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f"))
        {
            shout3 = false;
        }

        if (chasing || Input.GetKey("p"))
        {

            SoundCont();
            Sequence();
            an.SetBool("RUN", true);
            Chase(pl.position);
        }
    }

    public void Timer()
    {
        time += 1 * Time.deltaTime;

        if (time < 0)
        {
            time = 0;
        }
    }

    public void SoundCont()
    {
        Timer();
        if (!shout)
        {
            ad.PlayOneShot(ac);
            shout = true;
        }

        if (!shout2)
        {
            ad.PlayOneShot(ac2);
            shout2 = true;
        }

        if (!shout3)
        {
            ad.PlayOneShot(ac1);
            shout3 = true;
        }
    }

    public void Sequence()
    {
        if (time < 0.1f)
        {
            shout = false;
        }

        if (time > 13f && time < 13.1f)
        {
            shout2 = false;
        }

        if (time >= 45f)
        {
            time = 12f;
        }
    }

    public void Chase(Vector3 target)
    {
        speed += 0.01f;
        float moving = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), target, moving);
    }
}
