using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColl : MonoBehaviour
{
    public Collider c1, c2;

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
        if (collision.collider == c2)
        {
            collided = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == c2)
        {
            collided = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider == c2)
        {
            collided = false;
        }
    }
}
