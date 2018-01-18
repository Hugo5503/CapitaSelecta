using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;
    private Vector3 startZoomPosition;

    private bool markerMode;
    private bool leftHeldIn;
    private bool timerRunning;

    private GameObject selectedObject;

    public GameObject cameraRig;
    public GameObject marker;

    // Use this for initialization
    void Start()
    {
        timerRunning = false;
        markerMode = false;
        trackedObj = this.GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))  // Is any DPad button pressed?
        {
            var touchpadAxis = controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
            if (touchpadAxis.x < .5f)
            {
                leftHeldIn = true;
                Debug.Log("Left");

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    if (hit.collider.gameObject.tag != "Ignore")
                    {
                        Debug.Log("Found an oject: " + hit.collider.gameObject.name);
                        if (hit.collider.gameObject.tag == "Island")
                        {
                            if(selectedObject != null)
                            {
                                DisableOldUI();
                            }

                            selectedObject = hit.collider.gameObject;
                            if (selectedObject.tag == "Island")
                            {
                                selectedObject.GetComponent<Island>().UIcollection.SetActive(true);
                            }
                        }
                        if (hit.collider.gameObject.tag == "Ship")
                        {
                            if (selectedObject != null)
                            {
                                DisableOldUI();
                            }

                            selectedObject = hit.collider.gameObject;
                            if (selectedObject.tag == "Ship")
                            {
                                selectedObject.GetComponent<ShipControl>().UIcollection.SetActive(true);
                            }
                        }
                    }
                }

                if (!markerMode)
                {
                    markerMode = true;
                }

            }

        }

        if (markerMode)
        {
            marker.SetActive(true);
        }
        else
        {
            marker.SetActive(false);
        }

        //Look if left is hold if so stop markermode...
        if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))  // Is any DPad button pressed?
        {
            var touchpadAxis = controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
            if (touchpadAxis.x < .5f)
            {
                if (!timerRunning)
                {
                    timerRunning = true;
                    StartCoroutine(wait());
                }
            }
        }

        if (controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            leftHeldIn = false;
        }

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

    IEnumerator wait()
    {
        Debug.Log("timer started");
        yield return new WaitForSeconds(2);
        if (leftHeldIn)
        {
            markerMode = false;
        }
        Debug.Log("timer ended markermode = " + markerMode);
        timerRunning = false;
    }

    private void DisableOldUI()
    {
        if (selectedObject.GetComponent<Island>() != null)
        {
            selectedObject.GetComponent<Island>().UIcollection.SetActive(false);
        }
        if (selectedObject.GetComponent<ShipControl>() != null)
        {
            selectedObject.GetComponent<ShipControl>().UIcollection.SetActive(false);
        }
    }
}