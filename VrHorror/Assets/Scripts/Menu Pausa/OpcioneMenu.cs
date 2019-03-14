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

    }

    public void Toggle_Llanos_Changed(bool newValue)
    {
        Debug.Log("Llanos activado");
        toggleCheche.isOn = false;
        movementTpRight.enabled = true;
        movementTouchpd.enabled = false;
    }

    public void Toggle_Cheche_Changed(bool newValue)
    {
        Debug.Log("Cheche activado");
        toggleLlanos.isOn = false;
        movementTpRight.enabled = false;
        movementTouchpd.enabled = true;
    }
}
