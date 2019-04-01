using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alpha : MonoBehaviour {

    //variables
    public Image imag;
    public GameObject obj;
    public float temps;
    

    private void Update()
    {
        if (obj)
        {
            ObjAlpha(obj);
        }

        if (imag)
        {
            ImgAlpha(imag);
        }
    }

    public void ImgAlpha(Image img)
    {
        Color temp = img.color;
        
        temp.a = temps;
        img.color = temp;
    }

    public void ObjAlpha(GameObject ob)
    {
        Color temp = ob.GetComponent<MeshRenderer>().material.color;

        temp.a = temps;
        ob.GetComponent<MeshRenderer>().material.color = temp;
    }
}
