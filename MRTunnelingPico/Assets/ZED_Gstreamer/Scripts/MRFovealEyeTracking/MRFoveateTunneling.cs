using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Tobii.G2OM;
//using Tobii.XR;
using Unity.XR.PXR;
using UnityEngine.XR;
//using DG.Tweening;
public class MRFoveateTunneling : MonoBehaviour
{

    public Transform MainCamera;
    public bool isTrackingEnabled = false;
    public bool visualize = false;
    public GameObject LeftVisualCue;
    public GameObject RightVisualCue;
    public GameObject LeftFrameTransform;
    public GameObject RightFrameTransform;
    public float transitTime= 0.002f;

    public Material LeftEye;
    public Material RightEye;
    private Matrix4x4 matrix;

    private float stereoDisparity;
    private bool isFading=false;

    private Vector2 LeftCurrentCenter = new Vector2(0.5f, 0.5f);
    private Vector2 RightCurrentCenter = new Vector2(0.5f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("eye tracking transit time: " + transitTime);
        Debug.Log("eye texture width: " + XRSettings.eyeTextureWidth + "eye texture height: " +  XRSettings.eyeTextureHeight);
    }

    // Update is called once per frame



    void Update()
    {
        Vector3 LeftEyeHitPos = new Vector3(0, 0, 0);
        Vector3 RightEyeHitPos = new Vector3(0, 0, 0);
        if (isTrackingEnabled)
        {
            if (MainCamera != null)
            {
                matrix = Matrix4x4.TRS(MainCamera.position, MainCamera.rotation, Vector3.one);
            }
            else
            {
                matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one);
            }
            
            
            bool result = (PXR_EyeTracking.GetCombineEyeGazePoint(out Vector3 Origin) && PXR_EyeTracking.GetCombineEyeGazeVector(out Vector3 Direction));
            PXR_EyeTracking.GetCombineEyeGazePoint(out Origin);
            PXR_EyeTracking.GetCombineEyeGazeVector(out Direction);
            var RealOriginOffset = matrix.MultiplyPoint(Origin);
            var DirectionOffset = matrix.MultiplyVector(Direction);


            if (result)
            {
                
                RaycastHit[] hits = Physics.RaycastAll(RealOriginOffset, DirectionOffset, 2);
                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit hit = hits[i];
                    //  Debug.Log("hit!" + "length :  "+ hits.Length  + "hit point:  " +  hit.point + "hit tag: "  +  hit.collider.tag + "hit name: " +  hit.collider.name);
                    if (hit.collider.tag == "MRTunneling" && hit.collider.name == "ZED Left Image")
                    {

                        
                        // calculate the UV coordinate
                        LeftEyeHitPos = new Vector3(hit.point.x - stereoDisparity / 2, hit.point.y, hit.point.z);
                        RightEyeHitPos = new Vector3(hit.point.x + stereoDisparity / 2, hit.point.y, hit.point.z);

                        Vector3 leftDisplacement = LeftFrameTransform.transform.InverseTransformPoint(LeftFrameTransform.GetComponent<Renderer>().bounds.center) - LeftFrameTransform.transform.InverseTransformPoint(LeftEyeHitPos);
                        Vector3 rightDisplacement = RightFrameTransform.transform.InverseTransformPoint(RightFrameTransform.GetComponent<Renderer>().bounds.center) - RightFrameTransform.transform.InverseTransformPoint(RightEyeHitPos);

                        Vector2 leftUVCenter = new Vector2(0.5f, 0.5f) - new Vector2(leftDisplacement.x, leftDisplacement.y);
                        Vector2 RightUVCenter = new Vector2(0.5f, 0.5f) - new Vector2(rightDisplacement.x, rightDisplacement.y);

                        //Debug.Log("left uv center: " + leftUVCenter.x + "  " + leftUVCenter.y);
                        //Debug.Log("right uv center: " + RightUVCenter.x + "  " + RightUVCenter.y);

                        if (!isFading)
                        {
                            StartCoroutine(MoveEyeFocusCenter(leftUVCenter, RightUVCenter));
                            //MoveEyeFocusCenter(leftUVCenter, RightUVCenter);
                        }
                    }

                }
            }
        }

        if (visualize)
        {
            LeftVisualCue.transform.position = LeftEyeHitPos;
            RightVisualCue.transform.position = RightEyeHitPos;

        }
    }

    IEnumerator MoveEyeFocusCenter(Vector2 leftNewCenter, Vector2 rightNewCenter)
    {
        // begin the transition
        isFading = true;
        float elapsedTime = 0.0f;

        while (elapsedTime< transitTime)
        {
            elapsedTime += Time.deltaTime;
            
            Vector2 newLeftVec = Vector2.Lerp(LeftCurrentCenter, leftNewCenter, elapsedTime / transitTime);
            Vector2 newRightVec = Vector2.Lerp(RightCurrentCenter, rightNewCenter, elapsedTime / transitTime);
            LeftEye.SetVector("_CentralCoord", newLeftVec);
            RightEye.SetVector("_CentralCoord", newRightVec);
            yield return null;
        }

        // finish teh transition
        LeftCurrentCenter = leftNewCenter; 
        RightCurrentCenter = rightNewCenter;

        isFading = false;
    }

}
