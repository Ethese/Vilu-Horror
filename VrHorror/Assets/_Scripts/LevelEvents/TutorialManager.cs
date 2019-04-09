using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject obj1, obj2;
    public TextMesh txt1, txt2, txt3;

    public bool ev1, ev2, ev3, st1Ready;
    public bool ev4, ev5, ev6, st2ready;

    private Interact i1, i2;

    // Start is called before the first frame update
    void Start()
    {
        i1 = obj1.GetComponent<Interact>();
    }

    // Update is called once per frame
    void Update()
    {
        Event1();

        if (ev1)
        {
            Event2();
        }

        if (ev2)
        {
            Event3();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "stage2")
        {
            st1Ready = true;
        }
    }

    public void Event1()// pick up
    {
        if (i1.examined)
        {
            ev1 = true;
        }
    }

    public void Event2()// Throw
    {
        
    }

    public void Event3()// Move
    {
        
    }
}
