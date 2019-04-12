using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vida;

public class Checkpoint : MonoBehaviour
{
    public VidaJugador vidaPlayer;
    
    public Renderer rnd;
    public Material checkpointOff;
    public Material checkpointOn;

    public bool check;

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
            if (other.tag.Equals("Hand"))
            {
                vidaPlayer.SetRespawnPoint(transform.position);
                vidaPlayer.SetRespawnPoint(transform.position);
                CheckpointOn();
                check = true;
            }
        }

        if (other.tag == "Body")
        {
            check = true;
        }

        if(tag.Equals("checkPoint"))
        {
            if (other.tag.Equals("Body"))
            {
                vidaPlayer.SetRespawnPoint(transform.position);
                CheckpointOn();
                check = true;
            }
        }
    }
}
