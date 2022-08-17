using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// All the functions related to playing videos
/// </summary>
public class ZEDGstreamerVideoSettings : MonoBehaviour
{
    public Material LeftEyeBlendMaterial;
    public Material RightEyeBlendMaterial;

    private Transform ZEDRightFrame;
    private Transform ZEDLeftFrame;

    private VSTGstreamerRenderPlane ZEDLeftRenderPlane;
    private VSTGstreamerRenderPlane ZEDRightRenderPlane;

    // Get OVR CameraRig from the Mixed reality Toolkits
    //void TryGetOVRCameraRig()
    //{
    //    OVRCameraRig rig = MixedRealityInputSystemProfile.FindObjectOfType<OVRCameraRig>();

    //    ZEDLeftFrame = rig.transform.Find("TrackingSpace/LeftEyeAnchor/ZED Left Image");
    //    ZEDRightFrame = rig.transform.Find("TrackingSpace/RightEyeAnchor/ZED Right Image");

    //    ZEDLeftRenderPlane = ZEDLeftFrame.transform.GetComponent<VSTGstreamerRenderPlane>();
    //    ZEDRightRenderPlane = ZEDRightFrame.transform.GetComponent<VSTGstreamerRenderPlane>();

    //}

    //void Start()
    //{
    //    TryGetOVRCameraRig();
    //}

    // Update is called once per frame
    void Update()
    {
        
    }

/*    public void ChangeZEDImageTransparency(SliderEventData eventData)
    {
        LeftEyeBlendMaterial.SetFloat("_Visibility", eventData.NewValue * 10);
        RightEyeBlendMaterial.SetFloat("_Visibility", eventData.NewValue * 10);
    }
*/
    public void StartStreaming()
    {
        ZEDLeftRenderPlane.m_Texture.Play();
        ZEDRightRenderPlane.m_Texture.Play();

    }

    public void StopStreaming()
    {
        ZEDLeftRenderPlane.m_Texture.Stop();
        ZEDRightRenderPlane.m_Texture.Stop();

    }

    public void OnRewind()
    {
        // playback 0.5s
        var position = ZEDLeftRenderPlane.m_Texture.Player.GetPosition() / 1000;
        var duration = ZEDLeftRenderPlane.m_Texture.Player.GetDuration() / 1000;

        var p = (position - 5000);
        if (p < 0)
            p = 0;
        ZEDLeftRenderPlane.m_Texture.Player.Seek(p * 1000);

        var position2 = ZEDRightRenderPlane.m_Texture.Player.GetPosition() / 1000;
        var duration2 = ZEDRightRenderPlane.m_Texture.Player.GetDuration() / 1000;

        var p2 = (position2 - 5000);
        if (p2 < 0)
            p2 = 0;
        ZEDRightRenderPlane.m_Texture.Player.Seek(p2 * 1000);


    }

    public void OnForward()
    {
        // play forward 0.5s 
        var position = ZEDLeftRenderPlane.m_Texture.Player.GetPosition() / 1000;
        var duration = ZEDLeftRenderPlane.m_Texture.Player.GetDuration() / 1000;

        var p = (position + 5000);
        if (p >= duration)
            p = duration;
        ZEDLeftRenderPlane.m_Texture.Player.Seek(p * 1000);

        var position2 = ZEDRightRenderPlane.m_Texture.Player.GetPosition() / 1000;
        var duration2 = ZEDRightRenderPlane.m_Texture.Player.GetDuration() / 1000;

        var p2 = (position2 + 5000);
        if (p2 >= duration2)
            p2 = duration2;
        ZEDRightRenderPlane.m_Texture.Player.Seek(p2 * 1000);
    }
}
