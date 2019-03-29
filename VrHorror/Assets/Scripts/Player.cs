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

    // Movement
    public float distance;
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
    }

    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "STAHP")
        {
            isMoving = false;
            Destroy(other.gameObject); // destroy marker2 on collision
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
        }

        if (leftHand.isUsing)
        {
            currentHand = leftHand;
        }
    }
    #endregion
}
