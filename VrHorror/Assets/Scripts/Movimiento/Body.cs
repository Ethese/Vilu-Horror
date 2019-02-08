using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public DashContr dc;
    public Sound stealth;

    public Transform parent;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        dc.isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dc.isMoving)
        {
            stealth.Moving(speed * 1.5f);
            Move(dc.SetDirection());
        }
        else
        {
            stealth.Still();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "STAHP")
        {
            dc.isMoving = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "STAHP")
        {
            dc.isMoving = false;
        }
    }

    public void Move(Vector3 target)
    {
        float moving = speed * Time.deltaTime;
        parent.localPosition = Vector3.MoveTowards(new Vector3(parent.localPosition.x, parent.localPosition.y, parent.localPosition.z), target, moving);
    }

}
