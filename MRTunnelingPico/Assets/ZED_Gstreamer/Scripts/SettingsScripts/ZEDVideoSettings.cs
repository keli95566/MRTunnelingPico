using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.XR.PXR;
//using VRUiKits.Utils;
using TMPro;
//using Renci.SshNet;

public class ZEDVideoSettings : MonoBehaviour
{
    //public Material LeftEyeBlendMaterial;
    //public Material RightEyeBlendMaterial;

    //public GameObject ZEDRightFrame;
    //public GameObject ZEDLeftFrame;

    //public Slider TransparencySlider;
    //public OptionsManager PeripheralOption;
    //public OptionsManager ResolutionOption;
    //public OptionsManager EyeTrackingOption;
    //public OptionsManager FramerateOption;

    //public TMP_InputField GstreamerIP;
    //public SSHSetupManager sshManager;
    //public TMP_InputField headsetIPInput;
    //public string MyIP = "192.168.178.49";
    ////public OptionsManager 
    //private VSTGstreamerRenderPlane ZEDLeftRenderPlane;
    //private VSTGstreamerRenderPlane ZEDRightRenderPlane;

    //private int frameRate;
    //private int CameraResolutionIndex;
    //private string commandString;

    //private System.Threading.Thread commandThread;

    //void Start()
    //{
    //    ZEDLeftRenderPlane = ZEDLeftFrame.transform.GetComponent<VSTGstreamerRenderPlane>();
    //    ZEDRightRenderPlane = ZEDRightFrame.transform.GetComponent<VSTGstreamerRenderPlane>();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //#region peripheral Settings
    //public void OnSetPeripheralConfirm()
    //{
    //    Debug.Log(PeripheralOption.selectedValue);
    //    if(PeripheralOption.selectedValue == "Yes")
    //    {
    //        TurnOnPeripherial();
    //    }
    //    if(PeripheralOption.selectedValue == "No")
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

    //public void ChangeZEDImageTransparency()
    //{
    //    LeftEyeBlendMaterial.SetFloat("_Visibility", TransparencySlider.value);
    //    RightEyeBlendMaterial.SetFloat("_Visibility", TransparencySlider.value);
    //}

    //#endregion

    //#region streaming quality settings
    //public void ChangeImageResolution()
    //{
    //    // update streaming parameters
    //    frameRate = int.Parse(FramerateOption.selectedValue);

    //    if (ResolutionOption.selectedValue == "HD720")
    //    {
    //        ZEDLeftRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.HD720;
    //        ZEDRightRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.HD720;
    //        CameraResolutionIndex = 2;
    //        commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={frameRate} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue  ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert ! omxh264enc! 'video/x-h264, stream-format=(string)byte-stream' ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert  ! omxh264enc !  'video/x-h264, stream-format=(string)byte-stream'  ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";

    //    }
    //    if (ResolutionOption.selectedValue == "VGA")
    //    {
        
    //        ZEDLeftRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.VGA;
    //        ZEDRightRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.VGA;
    //        CameraResolutionIndex = 3;
    //        commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={frameRate} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue  ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert ! omxh264enc! 'video/x-h264, stream-format=(string)byte-stream' ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert  ! omxh264enc !  'video/x-h264, stream-format=(string)byte-stream'  ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";

    //    }
    //    if (ResolutionOption.selectedValue == "HD1080")
    //    {
    //        ZEDLeftRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.HD1080;
    //        ZEDRightRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.HD1080;
    //        CameraResolutionIndex = 1;
    //        commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={frameRate} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue  ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert ! omxh264enc! 'video/x-h264, stream-format=(string)byte-stream' ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert  ! omxh264enc !  'video/x-h264, stream-format=(string)byte-stream'  ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";

    //    }
    //    if (ResolutionOption.selectedValue == "HD2K")
    //    {
    //        ZEDLeftRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.HD2K;
    //        ZEDRightRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.HD2K;
    //        CameraResolutionIndex = 0;
    //        commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={frameRate} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue  ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert ! omxh264enc! 'video/x-h264, stream-format=(string)byte-stream' ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert  ! omxh264enc !  'video/x-h264, stream-format=(string)byte-stream'  ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";

    //    }
    //    if (ResolutionOption.selectedValue == "HD1080_50%")
    //    {
    //        ZEDLeftRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.HD1080Crop;
    //        ZEDRightRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.HD1080Crop;
    //        CameraResolutionIndex = 1;
    //        commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={frameRate} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert! nvvidconv left=480 right=1440 top=270 bottom=810  ! omxh264enc preset-level=0 !  'video/x-h264, stream-format=(string)byte-stream, width=960, height=540' ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert !  nvvidconv left=480 right=1440 top=270 bottom=810 ! omxh264enc preset-level=0 ! 'video/x-h264, stream-format=(string)byte-stream, width=960, height=540'  ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";
    //    }
    //    if (ResolutionOption.selectedValue == "HD720_80%")
    //    {
    //        ZEDLeftRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.HD720Crop;
    //        ZEDRightRenderPlane.resolution = VSTGstreamerRenderPlane.RESOLUTION.HD720Crop;

    //        CameraResolutionIndex = 2;
    //        commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={frameRate} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert! nvvidconv  left=108 right=972 top=57 bottom=663  ! omxh264enc preset-level=0 !  'video/x-h264, stream-format=(string)byte-stream ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert !  nvvidconv left=108 right=972 top=57 bottom=663 ! omxh264enc preset-level=0 ! 'video/x-h264, stream-format=(string)byte-stream'  ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients={MyIP}:5000 max-bitrate=30000000 sync=false async=false";
    //    }
    //}


    //public void OnChangeStreamingSettings()
    //{

    //    // We must first stop the existing streaming process via ssh and start a new streaming via different parameters
    //    StopStreaming();
    //    sshManager.TestGstreamerConnection();
    //    sshManager.RunSSHCommand("pkill gst-launch-1.0");
    //    //ZEDLeftRenderPlane.enabled = false;
    //    //ZEDRightRenderPlane.enabled = false;
    //    ChangeImageResolution();
    //    // terminate exsiting process
    //    // commandString = $"gst-launch-1.0 zedsrc camera-resolution={CameraResolutionIndex} camera-fps={frameRate} stream-type=2 enable-positional-tracking=false depth-stabilization=false ! queue  ! zeddemux is-depth=false name=demux demux.src_left  ! queue ! autovideoconvert ! omxh264enc! 'video/x-h264, stream-format=(string)byte-stream' ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients=192.168.178.49:5001 max-bitrate=30000000 sync=false async=false demux.src_aux ! queue ! autovideoconvert  ! omxh264enc !  'video/x-h264, stream-format=(string)byte-stream'  ! h264parse ! rtph264pay config-interval=-1 pt=96 ! queue ! udpsink clients=192.168.178.49:5000 max-bitrate=30000000 sync=false async=false";
    //    if (commandThread != null)
    //    {
    //        commandThread.Abort();
    //        Debug.Log("previous thread abort");
    //    }
    //    commandThread = sshManager.StartNewSSHCommandThreads(commandString); // replace with a new thread
    //   // Debug.Log(commandString);
    //    //ZEDLeftRenderPlane.enabled = true;
    //    //ZEDRightRenderPlane.enabled = true;
    //    ZEDLeftRenderPlane.setupGstreamerTexture();
    //    ZEDRightRenderPlane.setupGstreamerTexture();
    //    //StartStreaming();
    //}
    //#endregion

    //#region playback command
    //public void StartStreaming()
    //{
    //    ZEDLeftRenderPlane.m_Texture.Play();
    //    ZEDRightRenderPlane.m_Texture.Play();

    //}

    //public void StopStreaming()
    //{
    //    ZEDLeftRenderPlane.m_Texture.Stop();
    //    ZEDRightRenderPlane.m_Texture.Stop();

    //}

    //public void PauseStreaming()
    //{
    //    ZEDLeftRenderPlane.m_Texture.Pause();
    //    ZEDRightRenderPlane.m_Texture.Pause();

    //}

    //public void ResetStreaming()
    //{
    //    ZEDLeftRenderPlane.setupGstreamerTexture();
    //    ZEDRightRenderPlane.setupGstreamerTexture();

    //}
    //public void OnRewind()
    //{
    //    // playback 0.5s
    //    var position = ZEDLeftRenderPlane.m_Texture.Player.GetPosition() / 1000;
    //    var duration = ZEDLeftRenderPlane.m_Texture.Player.GetDuration() / 1000;

    //    var p = (position - 5000);
    //    if (p < 0)
    //        p = 0;
    //    ZEDLeftRenderPlane.m_Texture.Player.Seek(p * 1000);

    //    var position2 = ZEDRightRenderPlane.m_Texture.Player.GetPosition() / 1000;
    //    var duration2 = ZEDRightRenderPlane.m_Texture.Player.GetDuration() / 1000;

    //    var p2 = (position2 - 5000);
    //    if (p2 < 0)
    //        p2 = 0;
    //    ZEDRightRenderPlane.m_Texture.Player.Seek(p2 * 1000);


    //}

    //public void OnForward()
    //{
    //    // play forward 0.5s 
    //    var position = ZEDLeftRenderPlane.m_Texture.Player.GetPosition() / 1000;
    //    var duration = ZEDLeftRenderPlane.m_Texture.Player.GetDuration() / 1000;

    //    var p = (position + 5000);
    //    if (p >= duration)
    //        p = duration;
    //    ZEDLeftRenderPlane.m_Texture.Player.Seek(p * 1000);

    //    var position2 = ZEDRightRenderPlane.m_Texture.Player.GetPosition() / 1000;
    //    var duration2 = ZEDRightRenderPlane.m_Texture.Player.GetDuration() / 1000;

    //    var p2 = (position2 + 5000);
    //    if (p2 >= duration2)
    //        p2 = duration2;
    //    ZEDRightRenderPlane.m_Texture.Player.Seek(p2 * 1000);
    //}
    //#endregion
}
