using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

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
    public float leftSpeed;
    public float rightSpeed;

    // Movement
    public bool isMoving;
    public float speed;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        stealth = this.GetComponent<Sound>();
        currentHand = null;
        parent = transform.parent;

    }

    // Update is called once per frame
    void Update()
    {
        leftSpeed = leftHand.handSpeed;
        rightSpeed = rightHand.handSpeed;

        GetHand(); // get current hand using button

        if (isMoving)
        {
            stealth.Moving(speed * 1.5f); // aumentar radio 
            Move(currentHand.SetDirection());
        }
        else
        {
            stealth.Still(); // Hidden
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
    }
    #endregion

    #region Methods
    public void Move(Vector3 target)
    {
        float moving = speed * Time.deltaTime;
        parent.localPosition = Vector3.MoveTowards(new Vector3(parent.localPosition.x, parent.localPosition.y, parent.localPosition.z), target, moving);
        Debug.Log(currentHand.SetDirection());
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
        if (rightSpeed > 6f && leftSpeed > 6f)
        {
            float extraSpeed = rightSpeed + leftSpeed;
            speed = speed + extraSpeed * 0.1f;
        }
        else
        {
            speed = 3;
        }
    }
    #endregion
}
