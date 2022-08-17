using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.XR.PXR;
//using VRUiKits.Utils;
using TMPro;
public class ZEDSBSVideoSettings : MonoBehaviour
{

    //public CustomSBSPipelinePlayer SBSPlayer;

    //public OptionsManager PeripheralOption;
    //public OptionsManager ResolutionOption;
    //public OptionsManager EyeTrackingOption;
    //public OptionsManager DynamicTransparencyOption;
    //public OptionsManager CameraTimeWarpOption;

    //public GameObject PhysicsDataVisualizer;
    //public GameObject DynamicsAccomodator;

    //public GameObject EyetrackingManager;

    //public Material LeftEyeBlendMaterial;
    //public Material RightEyeBlendMaterial;

    //public Slider MidFoveatSlider;
    //public Slider CentralFoveatSlider;
    //public Slider AngularSpeedThresholdSlider;
    //public Slider TranslationalSpeedThresholdSlider;
    //public Slider EyeTrackingLerpTimeSlider;

    //public DynamicTransparencyAccmomodation DynamicTransparencyAccom;
    //public MRFoveateTunneling EyeTrackingMRTunneling;
    //public CameraTimeWrap cameraTimewarp;

    //private int CameraResolutionIndex;
    //private string commandString;
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //}
    //public void ChangeImageResolution()
    //{
    //    // update streaming parameters
    //    int frameRate = 30;
    //    string MyIP = "192.168.178.49";
    //    StopStreaming();
    //    SBSPlayer.m_Texture.Destroy();
    //    if (ResolutionOption.selectedValue == "HD720")
    //    {
    //       SBSPlayer.resolution = CustomSBSPipelinePlayer.RESOLUTION.HD720;
    //       CameraResolutionIndex = 2;
    //       commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={30} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue  ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert ! omxh264enc! 'video/x-h264, stream-format=(string)byte-stream' ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert  ! omxh264enc !  'video/x-h264, stream-format=(string)byte-stream'  ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";

    //    }
    //    if (ResolutionOption.selectedValue == "VGA")
    //    {

    //        SBSPlayer.resolution = CustomSBSPipelinePlayer.RESOLUTION.VGA;

    //        CameraResolutionIndex = 3;
    //        commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={60} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue  ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert ! omxh264enc! 'video/x-h264, stream-format=(string)byte-stream' ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert  ! omxh264enc !  'video/x-h264, stream-format=(string)byte-stream'  ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";

    //    }
    //    if (ResolutionOption.selectedValue == "HD1080")
    //    {
    //        SBSPlayer.resolution = CustomSBSPipelinePlayer.RESOLUTION.HD1080;

    //        CameraResolutionIndex = 1;
    //        commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={15} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue  ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert ! omxh264enc! 'video/x-h264, stream-format=(string)byte-stream' ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert  ! omxh264enc !  'video/x-h264, stream-format=(string)byte-stream'  ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";

    //    }
    //    if (ResolutionOption.selectedValue == "HD2K")
    //    {
    //        SBSPlayer.resolution = CustomSBSPipelinePlayer.RESOLUTION.HD2K;
    //        CameraResolutionIndex = 0;
    //        commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={15} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue  ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert ! omxh264enc! 'video/x-h264, stream-format=(string)byte-stream' ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert  ! omxh264enc !  'video/x-h264, stream-format=(string)byte-stream'  ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";

    //    }
    //    if (ResolutionOption.selectedValue == "HD1080Crop")
    //    {
    //        SBSPlayer.resolution = CustomSBSPipelinePlayer.RESOLUTION.HD1080Crop;
    //        CameraResolutionIndex = 1;
    //        commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={30} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert! nvvidconv left=480 right=1440 top=270 bottom=810  ! omxh264enc preset-level=0 !  'video/x-h264, stream-format=(string)byte-stream, width=960, height=540' ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert !  nvvidconv left=480 right=1440 top=270 bottom=810 ! omxh264enc preset-level=0 ! 'video/x-h264, stream-format=(string)byte-stream, width=960, height=540'  ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";
    //    }
  
    //    if (ResolutionOption.selectedValue == "HD2KCrop")
    //    {
    //        SBSPlayer.resolution = CustomSBSPipelinePlayer.RESOLUTION.HD2KCrop;

    //        CameraResolutionIndex = 0;
    //        commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={15} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert! nvvidconv  left=108 right=972 top=57 bottom=663  ! omxh264enc preset-level=0 !  'video/x-h264, stream-format=(string)byte-stream ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert !  nvvidconv left=108 right=972 top=57 bottom=663 ! omxh264enc preset-level=0 ! 'video/x-h264, stream-format=(string)byte-stream'  ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";
    //    }

    //    SBSPlayer.SetupStreaming();
    //}

    //#region dynamic transparency control

    //public void OnDynamicTransparencyConfirm()
    //{
    //    if(DynamicTransparencyOption.selectedValue == "Yes")
    //    {
    //        TurnOnTransAccomodation();
    //    }
    //    if(DynamicTransparencyOption.selectedValue == "No")
    //    {
    //        TurnOffTransAccomodation();
    //    }
    //}

    //public void TurnOnTransAccomodation()
    //{
    //    PhysicsDataVisualizer.SetActive(true);
    //    DynamicsAccomodator.SetActive(true);

    //}

    //public void TurnOffTransAccomodation()
    //{

    //    PhysicsDataVisualizer.SetActive(false);
    //    DynamicsAccomodator.SetActive(false);
    //}

    //public void OnAngularSpeedThresholdChange()
    //{
    //    DynamicTransparencyAccom.angularSpeedThreshold = AngularSpeedThresholdSlider.value;
    //}
    
    //public void OnTranslationalSpeedThresholdChange()
    //{
    //    DynamicTransparencyAccom.translationSpeedThreshold = TranslationalSpeedThresholdSlider.value;
    //}
    //#endregion

    //#region peripheral Settings
    //public void OnSetPeripheralConfirm()
    //{
    //    if (PeripheralOption.selectedValue == "Yes")
    //    {
    //        TurnOnPeripherial();
    //    }
    //    if (PeripheralOption.selectedValue == "No")
    //    {
    //        TurnOffPeripheral();
    //    }
    //}

    //public void TurnOnPeripherial()
    //{
    //    PXR_Boundary.EnableSeeThroughManual(true);
    //    PXR_Plugin.Pxr_SetGuardianSystemDisable(true);
    //}

    //public void TurnOffPeripheral()
    //{
    //    PXR_Boundary.EnableSeeThroughManual(false);
    //    PXR_Plugin.Pxr_SetGuardianSystemDisable(true);

    //}

    //// change mid foveate radius
    //public void ChangeMidFoveatRadius()
    //{
    //    LeftEyeBlendMaterial.SetFloat("_MidFoveateRadius", MidFoveatSlider.value);
    //    RightEyeBlendMaterial.SetFloat("_MidFoveateRadius", MidFoveatSlider.value);
    //}

    //// change central foveate radius
    //public void ChangCentralFoveateRadius()
    //{
    //    LeftEyeBlendMaterial.SetFloat("_CentralRadius", CentralFoveatSlider.value);
    //    RightEyeBlendMaterial.SetFloat("_CentralRadius", CentralFoveatSlider.value);
    //}


    //#endregion

    //#region eye tracking
    //public void OnSetEyeTrackingConfirm()
    //{
    //    if (EyeTrackingOption.selectedValue == "Yes")
    //    {
    //        TurnOnEyeTracking();
    //    }
    //    if (EyeTrackingOption.selectedValue == "No")
    //    {
    //        TurnOffEyeTracking();
    //    }
    //}
    //public void TurnOnEyeTracking()
    //{
        
    //    EyetrackingManager.SetActive(true);
    //}

    //public void TurnOffEyeTracking()
    //{

    //    EyetrackingManager.SetActive(false);
    //    LeftEyeBlendMaterial.SetVector("_CentralCoord", new Vector2(0.5f,0.5f));
    //    RightEyeBlendMaterial.SetVector("_CentralCoord", new Vector2(0.5f, 0.5f));
    //}

    //public void OnEyeTrackingLerpTimeChange()
    //{
    //    EyeTrackingMRTunneling.transitTime = EyeTrackingLerpTimeSlider.value;
    //}

    //#endregion

    //#region camera time warp
    //public void OnSetCameraTimeWarpConfirm()
    //{
    //    if (CameraTimeWarpOption.selectedValue == "Yes")
    //    {
    //        TurnOnEyeTracking();
    //    }
    //    if(CameraTimeWarpOption.selectedValue == "No")
    //    {
    //        TurnOffTimeWarp();
    //    }
    //}

    //public void TurnOnTimeWarp()
    //{
    //    cameraTimewarp.enableTimeWrap = true;
    //    cameraTimewarp.elapsedTime = 0;
    //}

    //public void TurnOffTimeWarp()
    //{
    //    cameraTimewarp.enableTimeWrap = false;
    //}
    //#endregion

    //#region playback command
    //public void StartStreaming()
    //{
    //    SBSPlayer.m_Texture.Play();

    //}

    //public void StopStreaming()
    //{
    //    SBSPlayer.m_Texture.Stop();

    //}

    //public void PauseStreaming()
    //{
    //    SBSPlayer.m_Texture.Pause();
    //}


    //public void OnRewind()
    //{
    //    // playback 0.5s
    //    var position = SBSPlayer.m_Texture.Player.GetPosition() / 1000;
    //    var duration = SBSPlayer.m_Texture.Player.GetDuration() / 1000;

    //    var p = (position - 5000);
    //    if (p < 0)
    //        p = 0;
    //    SBSPlayer.m_Texture.Player.Seek(p * 1000);


    //}

    //public void OnForward()
    //{
    //    // play forward 0.5s 
    //    var position = SBSPlayer.m_Texture.Player.GetPosition() / 1000;
    //    var duration = SBSPlayer.m_Texture.Player.GetDuration() / 1000;

    //    var p = (position + 5000);
    //    if (p >= duration)
    //        p = duration;
    //    SBSPlayer.m_Texture.Player.Seek(p * 1000);


    //}
    //#endregion
}
