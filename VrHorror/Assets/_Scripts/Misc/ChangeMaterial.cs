using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

    public Material[] m_Material;
    Renderer rend;

    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = m_Material[0];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fuego")
        {
            rend.sharedMaterial = m_Material[1];
        }
    }
}
