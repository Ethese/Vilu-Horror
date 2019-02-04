using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlpha : MonoBehaviour {

    //variables
    public Image imag;
    public float temps;

    private void Update()
    {
        alpha(imag);
    }

    public void alpha(Image img)
    {
        Color temp = img.color;
        //0.5
        temp.a = temps;
        img.color = temp;
    }
}
