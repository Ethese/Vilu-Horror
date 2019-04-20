using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using vida;

public class Player : MonoBehaviour
{
    #region Variables
    // Stealth
    private Sound stealth;

    // Hands
    public Hand leftHand;
    public Hand rightHand;
    private Hand currentHand;

    // References
    private Transform parent;
    private AudioSource aud;
    public Animator an;
    public VidaJugador vida;
    public float leftSpeed;
    public float rightSpeed;

    // Movement
    public bool isMoving;
    public float speed;
    public float time;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        stealth = GetComponent<Sound>();
        currentHand = null;
        parent = transform.parent;
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        leftSpeed = leftHand.handSpeed;
        rightSpeed = rightHand.handSpeed;

        GetHand(); // get current hand using button

        if (isMoving)
        {
            time = 1 * Time.deltaTime;
            SoundCont();
            stealth.Moving(speed * 1.5f); // aumentar radio 
            Move(currentHand.SetDirection());
            an.SetBool("walking",true);
        }
        else
        {
            aud.Stop();
            stealth.Still(); // Hidden
            an.SetBool("walking",false);
        }

        Sprint();
    }

    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "STAHP")
        {
            Destroy(other.gameObject); // destroy marker2 on collision
            isMoving = false;
        }

        if (other.tag == "Finish")
        {
            vida.Death();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "STAHP")
        {
            Destroy(other.gameObject); // destroy marker2 on collision
            isMoving = false;
        }

        if (other.tag == "Finish")
        {
            vida.Death();
        }
    }
    #endregion

    #region Methods
    public void Move(Vector3 target)
    {
        float moving = speed * Time.deltaTime;
        parent.localPosition = Vector3.MoveTowards(new Vector3(parent.localPosition.x, parent.localPosition.y, parent.localPosition.z), target, moving);
    }

    public void GetHand()
    {
        if (rightHand.isUsing)
        {
            currentHand = rightHand;
            leftHand.isUsing = false;
        }

        if (leftHand.isUsing)
        {
            currentHand = leftHand;
            rightHand.isUsing = false;
        }
    }

    public void Sprint()
    {
        if (rightSpeed > 5f && leftSpeed > 5f)
        {
            float extraSpeed = 3;
            speed = speed + extraSpeed;
        }
        else
        {
            speed = 3;
        }
    }

    public void SoundCont()
    {
        if (!aud.isPlaying)
        {
            aud.Play();
        }
    }
    #endregion
}
