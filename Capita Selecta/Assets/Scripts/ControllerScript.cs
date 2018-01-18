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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            //print("Found an object - distance: " + hit.distance + " ObjectName: " + hit.collider.gameObject.name);
        }
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        if (controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
        {
            if (startZoomPosition == new Vector3())
            {
                startZoomPosition = this.transform.position;
            }
        }

        if (controller.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip))
        {
            float distance = transform.position.y - startZoomPosition.y;
            if (distance > .15f && cameraRig.transform.localScale.y < 30)
            {
                cameraRig.transform.localScale = new Vector3(cameraRig.transform.localScale.x + 0.1f, cameraRig.transform.localScale.y + 0.1f, cameraRig.transform.localScale.z + 0.1f);
            }
            if (distance < -.15f && cameraRig.transform.localScale.y > 1)
            {
                cameraRig.transform.localScale = new Vector3(cameraRig.transform.localScale.x - 0.1f, cameraRig.transform.localScale.y - 0.1f, cameraRig.transform.localScale.z - 0.1f);
            }
        }

        if (controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_Grip))
        {
            Debug.Log("reset");
            startZoomPosition = new Vector3();
        }
    }
}