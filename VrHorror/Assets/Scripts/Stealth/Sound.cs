using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public float moveVolume, impactVolume, awareness;
    public float soundRadio;

    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        soundRadio = 0.1f;
        moveVolume = 0.1f;
        impactVolume = 0.1f;

    }

    private void Update()
    {
        awareness = moveVolume + impactVolume;
        ball.transform.localScale = new Vector3(awareness, awareness, awareness);

        if (Input.GetKey("w"))
        {
            Moving(3);
        }

        if (!Input.anyKey)
        {
            Still();
        }
    }

    public void Still()
    {
        if (moveVolume > 0f)
        {
            moveVolume -= 10f * Time.deltaTime;
        }
    }

    public void Moving(float vel)
    {
        if (moveVolume < 100f)
        {
            moveVolume += vel * Time.deltaTime;
        }
    }

    public void Impact(float vel)
    {
        impactVolume += vel;
        if (impactVolume > 0f)
        {
            impactVolume -= 10f * Time.deltaTime;
        }
    }
}
