using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;



public class ZedCalibrationController : MonoBehaviour
{

    public DebugLogger debugLogger;
    List<InputDevice> devices;

    public float xOffset = 0.0001f;
    public float yOffset = 0.0001f;
    public float zOffset = 0.0001f;

    Vector3 initialLeftFramePos;
    Vector3 initialRightFramePos;

    Vector3 endLeftFramePos;
    Vector3 endRightFramePos;

    private float IPDChange = 0;
    private float xdiff = 0;
    private float ydiff = 0;
    private float zdiff = 0;

    string calibAxis = "x";

    public Transform ZEDRightFrame;
    public Transform ZEDLeftFrame;



    Queue axisCalibQueue;

    private void Awake()
    {
        devices = new List<InputDevice>();
    }
    void Start()
    {
        GetControllers();
        axisCalibQueue = new Queue();
        //axisCalibQueue.Enqueue("IPD");
        axisCalibQueue.Enqueue("y");
        axisCalibQueue.Enqueue("z");
        axisCalibQueue.Enqueue("x");

        TryGetOVRCameraRig();
        //Debug.Log(devices);
    }

    // Get OVR CameraRig from the Mixed reality Toolkits
    void TryGetOVRCameraRig()
    {
       // OVRCameraRig rig = MixedRealityInputSystemProfile.FindObjectOfType<OVRCameraRig>();
        //var rig = GameObject.Find("OVRCameraRig");

/*        leftCamera = rig.transform.Find("TrackingSpace/LeftEyeAnchor").gameObject.GetComponent<Camera>();
        rightCamera = rig.transform.Find("TrackingSpace/RightEyeAnchor").gameObject.GetComponent<Camera>();
        
        leftCamera.stereoSeparation = 0.022f;
        leftCamera.stereoConvergence = 10;
        rightCamera.stereoSeparation = 0.022f;
        rightCamera.stereoConvergence = 10;

        ZEDLeftFrame = rig.transform.Find("TrackingSpace/LeftEyeAnchor/ZED Left Image");
        ZEDRightFrame = rig.transform.Find("TrackingSpace/RightEyeAnchor/ZED Right Image");*/
        initialLeftFramePos = ZEDLeftFrame.position;
        initialRightFramePos = ZEDRightFrame.position;
    }

    // Update is called once per frame
    void Update()
    {
        //FrameAdjustmentListener();
        // XRDeviceInputListener();

        if (calibAxis == "IPD")
        {
            CalibIPD();
        }

        if (calibAxis == "x")
        {
            CalibXAxis();
        }

        else if (calibAxis == "y")
        {
            CalibYAxis();
        }

        else if (calibAxis == "z") {

            CalibZAxis();
        }
    }

    void GetControllers()
    {
        InputDevices.GetDevices(devices);
       // InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
       // InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, devices);

    }



    // calibrate the distance between eyes 
    void CalibIPD()
    {

        foreach (var device in devices)
        {
            //Debug.Log(device.name + " " + device.characteristics);

            if (device.isValid)
            {
                Vector2 positionVector;

                if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out positionVector))
                {

                    Vector3 oldRightPos = ZEDRightFrame.position;
                    Vector3 oldLeftPos = ZEDLeftFrame.position;

                    if (positionVector.x > 0)
                    {
                        ZEDRightFrame.position = new Vector3(oldRightPos.x + xOffset, oldRightPos.y, oldRightPos.z);
                        // ZEDLeftFrame.position = new Vector3(oldLeftPos.x - xOffset, oldLeftPos.y, oldLeftPos.z);
                        IPDChange += xOffset;
                    }

                    else if (positionVector.x < 0)
                    {

                        ZEDRightFrame.position = new Vector3(oldRightPos.x - xOffset, oldRightPos.y, oldRightPos.z);
                        // ZEDLeftFrame.position = new Vector3(oldLeftPos.x + xOffset, oldLeftPos.y, oldLeftPos.z);

                        IPDChange -= xOffset;
                    }

                }

            }

        }
    }
    void CalibXAxis()
    {


        foreach (var device in devices)
        {
            //Debug.Log(device.name + " " + device.characteristics);

            if (device.isValid)
            {
                Vector2 positionVector;

                if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out positionVector))
                {

                    Vector3 oldRightPos = ZEDRightFrame.position;
                    Vector3 oldLeftPos = ZEDLeftFrame.position;

                    if (positionVector.x > 0)
                    {
                        ZEDRightFrame.position = new Vector3(oldRightPos.x + xOffset, oldRightPos.y, oldRightPos.z);
                        ZEDLeftFrame.position = new Vector3(oldLeftPos.x + xOffset, oldLeftPos.y, oldLeftPos.z);
                        xdiff += xOffset;
                    }

                    else if (positionVector.x < 0)
                    {

                        ZEDRightFrame.position = new Vector3(oldRightPos.x - xOffset, oldRightPos.y, oldRightPos.z);
                        ZEDLeftFrame.position = new Vector3(oldLeftPos.x - xOffset, oldLeftPos.y, oldLeftPos.z);

                        xdiff -= xOffset;
                    }
                    /*
                                        endRightFramePos = ZEDRightFrame.position;
                                        endLeftFramePos = ZEDLeftFrame.position;

                                        debugLogger.LogInfo("Right Frame Pos: " + endRightFramePos);
                                        debugLogger.LogError("Left Frame Pos: " + endLeftFramePos);*/
                }

            }

        }

    }

    void CalibYAxis()
    {


        foreach (var device in devices)
        {
            //Debug.Log(device.name + " " + device.characteristics);

            if (device.isValid)
            {
                Vector2 positionVector;

                if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out positionVector))
                {

                    Vector3 oldRightPos = ZEDRightFrame.position;
                    Vector3 oldLeftPos = ZEDLeftFrame.position;

                    if (positionVector.y > 0)
                    {
                        ZEDRightFrame.position = new Vector3(oldRightPos.x, oldRightPos.y + yOffset, oldRightPos.z);
                        ZEDLeftFrame.position = new Vector3(oldLeftPos.x, oldLeftPos.y + yOffset, oldLeftPos.z);
                        ydiff += yOffset;
                    }

                    else if (positionVector.y < 0)
                    {
                        ZEDRightFrame.position = new Vector3(oldRightPos.x, oldRightPos.y - yOffset, oldRightPos.z);
                        ZEDLeftFrame.position = new Vector3(oldLeftPos.x, oldLeftPos.y - yOffset, oldLeftPos.z);
                        ydiff -= yOffset;
                    }

                    //endRightFramePos = ZEDRightFrame.position;
                    //endLeftFramePos = ZEDLeftFrame.position;

                    //debugLogger.LogInfo("Right Frame Pos: " + endRightFramePos);
                    //debugLogger.LogError("Left Frame Pos: " + endLeftFramePos);
                }

            }

        }

    }

    void CalibZAxis()
    {


        foreach (var device in devices)
        {
            //Debug.Log(device.name + " " + device.characteristics);

            if (device.isValid)
            {
                Vector2 positionVector;

                if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out positionVector))
                {

                    Vector3 oldRightPos = ZEDRightFrame.position;
                    Vector3 oldLeftPos = ZEDLeftFrame.position;

                    if (positionVector.y > 0)
                    {
                        ZEDRightFrame.position = new Vector3(oldRightPos.x, oldRightPos.y, oldRightPos.z + zOffset);
                        ZEDLeftFrame.position = new Vector3(oldLeftPos.x, oldLeftPos.y, oldLeftPos.z + zOffset);
                        zdiff += zOffset;
                    }

                    else if (positionVector.y < 0)
                    {
                        ZEDRightFrame.position = new Vector3(oldRightPos.x, oldRightPos.y, oldRightPos.z - zOffset);
                        ZEDLeftFrame.position = new Vector3(oldLeftPos.x, oldLeftPos.y, oldLeftPos.z - zOffset);
                        zdiff -= zOffset;
                    }

                    //endRightFramePos = ZEDRightFrame.position;
                    //endLeftFramePos = ZEDLeftFrame.position;

                    //debugLogger.LogInfo("Right Frame Pos: " + endRightFramePos);
                    //debugLogger.LogError("Left Frame Pos: " + endLeftFramePos);
                }

            }

        }

    }


    public void InvertImages()
    {
        Vector3 newRot = new Vector3(0, 0, ZEDLeftFrame.rotation.eulerAngles.z + 180);
        ZEDLeftFrame.eulerAngles = newRot;
        ZEDRightFrame.eulerAngles = newRot;
    }
    public void SwitchToNextAxis()
    {
        // set current calib value
        calibAxis = axisCalibQueue.Peek().ToString();
        // remove it from the queue
        axisCalibQueue.Dequeue();
        // put it at the end of the queue again
        axisCalibQueue.Enqueue(calibAxis);

        debugLogger.LogWarning("Calibrating " + calibAxis);
    }
    public void OnCalibrationEnd()
    {
        //debugLogger.LogInfo("Calibrated IPD: " + IPDChange);
        debugLogger.LogInfo("Position Offset x: " + xdiff);
        debugLogger.LogInfo("Position Offset y: " + ydiff);
        debugLogger.LogInfo("Position Offset z: " + zdiff);
        debugLogger.LogInfo("Final Local Transform Left: " + ZEDLeftFrame.localPosition.x + "   " + ZEDLeftFrame.localPosition.y +   "   " + ZEDLeftFrame.localPosition.z);
        debugLogger.LogInfo("Final Local Transform Right: " + ZEDRightFrame.localPosition.x + "   " + ZEDRightFrame.localPosition.y + "   " + ZEDRightFrame.localPosition.z);

    }

    public void ToggleRGBFrames()
    {
        bool isActive = ZEDLeftFrame.gameObject.active;
        ZEDLeftFrame.gameObject.active = !isActive;
        ZEDRightFrame.gameObject.active = !isActive;

    }
    // For debugging 
    void XRDeviceInputListener()
    {

        foreach (var device in devices)
        {
            Debug.Log(device.name + " " + device.characteristics);

            if (device.isValid)
            {
                bool inputValue;

                if (device.TryGetFeatureValue(CommonUsages.primaryButton, out inputValue) && inputValue)
                {
                    // Debug.Log("Detected Primary button pressed!");
                }

            }

        }
    }
}
