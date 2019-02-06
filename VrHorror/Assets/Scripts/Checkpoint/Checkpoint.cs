﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vida;

public class Checkpoint : MonoBehaviour
{
    public VidaJugador vidaPlayer;

    public Renderer rnd;
    public Material checkpointOff;
    public Material checkpointOn;

    // Start is called before the first frame update
    void Start()
    {
        vidaPlayer = FindObjectOfType<VidaJugador>();
        Debug.Log(tag);
        //rnd = GetComponent<Renderer>();
    }

    void CheckpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach(Checkpoint cp in checkpoints)
        {
            cp.CheckpointOff();
        }

        rnd.material = checkpointOn;
    }

    void CheckpointOff()
    {
        rnd.material = checkpointOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tag.Equals("savePoint"))
        {
            if (other.tag.Equals("hand"))
            {
                vidaPlayer.SetRespawnPoint(transform.position);
                vidaPlayer.SetRespawnPoint(transform.position);
                CheckpointOn();
            }
        }
        if(tag.Equals("checkPoint"))
        {
            if (other.tag.Equals("body"))
            {
                vidaPlayer.SetRespawnPoint(transform.position);
                CheckpointOn();
            }
        }
    }
}
