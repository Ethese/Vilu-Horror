using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRail : MonoBehaviour
{
    public Rail rail;

    private int currentSeg;
    private float transition;
    private bool isCompleted;

    private void Update()
    {
        if (!rail)
        {
            return;
        }
        if (!isCompleted)
        {
            Play();
        }
    }

    private void Play()
    {
        transition += Time.deltaTime * 1 / 2.5f;
        if (transition > 1)
        {
            transition = 0;
            currentSeg++;
        }else if(transition < 0)
        {
            transition = 1;
            currentSeg++;
        }

        transform.position = rail.linealPosition(currentSeg, transition);
        transform.rotation = rail.Orientaion(currentSeg, transition);
    }
}
