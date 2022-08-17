using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.PXR;
public class ApplicationController : MonoBehaviour
{
    public GameObject[] AplicationList = new GameObject[5];
    public GameObject AppController;
    /*    private GameObject VideoSettingsApp;
        private GameObject CalibrationApp;
        private GameObject DLARExamplesAppController;
        private GameObject Postprocessing;
        private GameObject DebugPanel;
    */
    List<InputDevice> devices;
    string activeObjName = "VideoSettings";
    List<UnityEngine.XR.InputDevice> rightHandDevices = new List<UnityEngine.XR.InputDevice>();
    UnityEngine.XR.InputDevice rightController;
    bool wasPrimaryPressed = false;
    bool primaryButtonState;

    private void Awake()
    {
        // conrtoller initialization
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        if (rightHandDevices.Count == 1)
        {
            rightController = rightHandDevices[0];
        }
    }
    void Start()
    {
        GetControllers();
    }

    // Update is called once per frame
    void Update()
    {

        // we need this button to toggle ZED streaming to make sure it is streamed correctly before giving the device to the participant
        bool isPrimaryPressed = rightController.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonState);
        if (isPrimaryPressed && primaryButtonState && !wasPrimaryPressed)
        {
            bool isActive = AppController.active;

            AppController.SetActive(!isActive);

            if (AppController.active == false)
            {
                foreach (GameObject obj in AplicationList)
                {

                    obj.SetActive(false);
                }
            }
            else
            {
                SetGameObjActive(activeObjName);
            }

            wasPrimaryPressed = true;
        }
        else if (!primaryButtonState)
        {
            wasPrimaryPressed = false;
        }

    }
    void GetControllers()
    {
        //InputDevices.GetDevices(devices);
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
        // InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, devices);

    }

    private void SetGameObjActive(string objName)
    {
        foreach(GameObject obj in AplicationList)
        {
            if (obj.name!= objName)
            {
                obj.SetActive(false);
            }
            else
            {
                obj.SetActive(true);
                activeObjName = objName;
            }
        }
    }


    public void ToggleDebugPanelApp()
    {

        SetGameObjActive("LogPanel");
    }

    public void TogglePostProcessingApp()
    {

        SetGameObjActive("VideoEffects");
    }

    public void ToggleLatencyMeasurementApp()
    {
        SetGameObjActive("LatencyMeasurement");
    }

    public void ToggleDLARExamplesApp()
    {

        SetGameObjActive("FunExperiments");

    }

    public void ToggleCalibrationApp()
    {

        SetGameObjActive("ViewCalibrationApp");
    }
    public void ToggleVideoSettingApp()
    {

        SetGameObjActive("VideoSettings");
    }
}
