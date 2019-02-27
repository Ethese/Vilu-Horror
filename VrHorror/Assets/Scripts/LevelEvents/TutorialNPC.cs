using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNPC : MonoBehaviour
{
    public TutorialManager tm;
    public Transform pos1, pos2, pos3;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Stage1();
    }

    public void ChangePosition(Vector3 posB)
    {
        speed = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, posB, speed);
    }

    public void Stage1()
    {
        if (tm.ev2) // al terminar el segundo evento se prepara para el tercero
        {
            ChangePosition(pos1.position);
        }
    }
}
