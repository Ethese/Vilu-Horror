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

    }

    private void ProcesRelease(PointerEventData data)
    {

    }
}
