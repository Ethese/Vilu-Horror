using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public Checkpoint cp,cp1,cp2,cp3;

    public GameObject cinematicPl, player;

    public AudioSource car1, car2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cp.check)
        {
            CarScene();
        }
    }

    public void CarScene()
    {
        car1.Stop();
        if (cp1.check)
        {
            car2.Play();
            cinematicPl.SetActive(false);
            player.SetActive(true);
        }
    }
    
}
