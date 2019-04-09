using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var puntos = new Vector3[] { new Vector3(0, 0, 0), new Vector3(196, 0, 9), new Vector3(145, 0, -22), new Vector3(162, 0, 34) };
        var camino = new GoSpline(puntos);
        camino.closePath();
        Go.to(transform, 25f, new GoTweenConfig().positionPath(camino, true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
