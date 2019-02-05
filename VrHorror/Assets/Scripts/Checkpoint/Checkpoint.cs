using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vida;

public class Checkpoint : MonoBehaviour
{
    public VidaJugador vidaPlayer;

    Renderer rnd;
    public Material checkpointOff;
    public Material checkpointOn;

    // Start is called before the first frame update
    void Start()
    {
        vidaPlayer = FindObjectOfType<VidaJugador>();
        rnd = GetComponent<Renderer>();
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
        if(other.tag.Equals("Player"))
        {
            vidaPlayer.SetRespawnPoint(transform.position);
            CheckpointOn();
        }
    }
}
