using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpcioneMenu : MonoBehaviour
{
    //Toggles
    public Toggle toggleLlanos;
    public Toggle toggleCheche;

    //ScriptsMovimiento
    public MovementTouchpad movementTouchpd;
    DashContr movementTpLeft;
     public DashContr movementTpRight;

    // Start is called before the first frame update
    void Start()
    {
        toggleCheche.isOn = true;
        toggleLlanos.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleLlanos.isOn)
        {
            toggleCheche.isOn = false;
        }
        else
        {
            toggleLlanos.isOn = false;
        }
    }

    public void Toggle_Llanos_Changed(bool newValue)
    {
        toggleCheche.interactable = newValue;
    }

    public void Toggle_Cheche_Changed(bool newValue)
    {
        toggleCheche.interactable = newValue;
    }
}
