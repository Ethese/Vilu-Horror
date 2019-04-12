using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY : MonoBehaviour
{
    public bool chasing;
    public float speed;

    public AudioSource ad;
    public Transform pl;
    public Animator an;

    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing || Input.GetKey("space"))
        {
            ad.Play();
            an.SetBool("RUN", true);
            Chase(pl.position);
        }
    }

    public void Chase(Vector3 target)
    {

        float moving = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), target, moving);
    }
}
