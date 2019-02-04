using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class AlinearEstatura : MonoBehaviour
{
    public Transform cabeza;
    public Transform pies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pies.position = new Vector3(cabeza.position.x, pies.position.y, cabeza.position.z);
    }
}
