using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public DashContr dc;

    public Transform parent;

    public float speed;
    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Move(dc.SetDirection());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "")
        {
            isMoving = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "")
        {
            isMoving = false;
        }
    }

    public void Move(Vector3 target)
    {
        float moving = speed * Time.deltaTime;
        parent.localPosition = Vector3.MoveTowards(new Vector3(parent.localPosition.x, parent.localPosition.y, parent.localPosition.z), target, moving);
    }

}
