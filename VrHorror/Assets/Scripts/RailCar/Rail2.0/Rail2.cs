using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail2 : MonoBehaviour
{
    public Transform auto;
    // Start is called before the first frame update
    void Start()
    {
        var points = new Vector3[] { new Vector3(0, 0, 0), new Vector3(132.8f, 55f, 45f), new Vector3(168, 16, 14), new Vector3(-51, 94, 134), new Vector3(222, 48, 88) };
        var path = new GoSpline(points);
        path.closePath();

        Go.to(auto, 35, new GoTweenConfig().positionPath(path, true));
    }

    // Update is called once per frame
    void Update()
    {
    }

    
}
