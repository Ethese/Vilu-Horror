using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColl : MonoBehaviour
{
    public string objName;

    private Collider c1, c2;

    public bool collided;

    // Start is called before the first frame update
    void Start()
    {
        c1 = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            Ignore();
        }
    }

    public void Ignore()
    {
        Physics.IgnoreCollision(c1,c2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == objName)
        {
            collided = true;
            c2 = collision.gameObject.GetComponent<Collider>();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == objName)
        {
            collided = true;
            c2 = collision.gameObject.GetComponent<Collider>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == objName)
        {
            collided = false;
            c2 = null;
        }
    }
}
