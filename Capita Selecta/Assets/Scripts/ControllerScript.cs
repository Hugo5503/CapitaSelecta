using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;
    private Vector3 startZoomPosition;

    public GameObject cameraRig;

    // Use this for initialization
    void Start()
    {
        trackedObj = this.GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward))
        {

        }
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        if (controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
        {
            if (startZoomPosition == new Vector3())
            {
                startZoomPosition = this.transform.position;
            }
            if(Vector3.Distance(this.transform.position, startZoomPosition) > 1)
            {
                cameraRig.transform.localScale = cameraRig.transform.localScale * +1;
            }
            if (Vector3.Distance(this.transform.position, startZoomPosition) < 1)
            {
                cameraRig.transform.localScale = cameraRig.transform.localScale * -1;
            }
            Debug.Log("OOohhhh scaling shit " + Vector3.Distance(this.transform.position, startZoomPosition));
        }
        
        if (controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_Grip))
        {
            startZoomPosition = new Vector3();
        }
    }
}