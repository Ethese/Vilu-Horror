using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Valve.VR;

public class SistemaInventario : MonoBehaviour
{
    public SteamVR_Action_Single squeeze;
    public GameObject inventory;
    private bool inventoryEnabled;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;
    void Start()
    {
        allSlots = 1;
        slot = new GameObject[allSlots];
        for (int i =0;i<allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item == null)
                slot[i].GetComponent<Slot>().empty = true;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (squeeze.GetAxis(SteamVR_Input_Sources.Any) > 0)
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled == true)
        {
            //PausarJuego();
            inventory.SetActive(true);
        }
        else
        {
           // Volver();
            inventory.SetActive(false);
        }
    }

    /*private void PausarJuego()
    {
        //Mostrar Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //Desactivar Movimiento de Juego
        Time.timeScale = 0f;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
    }

    private void Volver()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Item")
        {
            print("Item Recogido");
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();
            AddItem(itemPickedUp,item.ID, item.type, item.description, item.icon);
        }
    }

    void AddItem(GameObject itemObject,int itemID,string itemTtype,string itemDescription,Sprite itemIcon)
    {
        for (int i= 0;i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                //añadir item
                itemObject.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon =itemIcon;
                slot[i].GetComponent<Slot>().type = itemTtype;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;
                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
            }

            return;
        }
       
    }
}
