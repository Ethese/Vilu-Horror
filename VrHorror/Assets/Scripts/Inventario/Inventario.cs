using System.Collections;
using System.Collections.Generic;
//using UnityStandardAssets.Characters.FirstPerson;
using System;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    public static bool Pausado = false;
    public GameObject Menu;

    private const int slots = 9;

    private List<InventarioItem> mItems = new List<InventarioItem>();

    public event EventHandler<InventarioEventArgs> ItemAnadido;

    public void AnadirItem(InventarioItem item)
    {
        if (mItems.Count < slots) 
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.Recogido();

                if (ItemAnadido !=null)
                {
                    ItemAnadido(this,new InventarioEventArgs(item));
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Pausado)
            {
                VolverAlJuego();
            }
            else
            {

                Pausa();
            }
        }
    }

    public void VolverAlJuego()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        //GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
        Pausado = false;
    }

    public void Pausa()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        //GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        Pausado = true;

    }

}
