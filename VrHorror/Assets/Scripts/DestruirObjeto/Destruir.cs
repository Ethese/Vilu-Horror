using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    public int tiempo=0;
    void Update()
    {
        DestroyObjectDelayed();
    }

    void DestroyObjectDelayed()
    {
       
        Destroy(gameObject, tiempo);
    }
}
