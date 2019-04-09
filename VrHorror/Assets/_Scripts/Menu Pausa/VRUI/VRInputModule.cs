using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VRInputModule : BaseInputModule
{
    public Camera camera;
    public SteamVR_Input_Sources targetSource;
    public SteamVR_Action_Boolean clickAction;

    private GameObject currentObject = null;
    private PointerEventData data = null;


    protected override void Awake()
    {
        base.Awake();

        data = new PointerEventData(eventSystem);
    }

    public override void Process()
    {
        //Reset data
        data.Reset();
        data.position = new Vector2(camera.pixelWidth / 2, camera.pixelHeight / 2);

        //Raycast
        eventSystem.RaycastAll(data, m_RaycastResultCache);
        data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        currentObject = data.pointerCurrentRaycast.gameObject;

        //Clear
        m_RaycastResultCache.Clear();

        //Hover
        HandlePointerExitAndEnter(data, currentObject);

        //Press
        if (clickAction.GetStateDown(targetSource))
        {
            //Debug.Log("Click");
            ProcessPress(data);
        }

        //Release
        if (clickAction.GetStateUp(targetSource))
        {
            ProcesRelease(data);
        }
    }

    public PointerEventData GetData()
    {
        return data;
    }

    private void ProcessPress(PointerEventData data)
    {
        //Seting a raycast
        data.pointerPressRaycast = data.pointerCurrentRaycast;

        //Check for object hit, get the down handler, call
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(currentObject, data, ExecuteEvents.pointerDownHandler);

        //if no down handler, try and get click handler
        if (newPointerPress == null)
        {
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);
        }

        //Set data
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = currentObject;
    }

    private void ProcesRelease(PointerEventData data)
    {
        //Execute pointer up
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);


        //Check for click handler
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);

        //check if actual
        if (data.pointerPress == pointerUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        //Clear selected GameObject
        eventSystem.SetSelectedGameObject(null);

        //Reset data
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;

    }
}
