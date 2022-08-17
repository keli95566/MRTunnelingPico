using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEDTransformManager : MonoBehaviour
{
    public Transform TrackHeadObj;
    public Transform LeftRenderPlane;
    public Transform RightRenderPlane;

    public bool enableTimeWarp = true;
    public int lagFrame = 3;
    public int FPS = 30;

    public Vector3 LeftPosOffset;
    public Quaternion LeftRotOffset;
    public Vector3 RightPosOffset;
    public Quaternion RightRotOffset;

    private List<Vector3> lagHeadPositions;
    private List<Quaternion> lagHeadRotations;

    Vector3 _currentHeadPosition;
    Quaternion _currentHeadRotation;

    private System.DateTime _nextUpdate;
    private System.DateTime _currentTime;

    void Start()
    {

        LeftPosOffset = LeftRenderPlane.position;
        RightPosOffset = RightRenderPlane.position;
        LeftRotOffset = LeftRenderPlane.rotation;
        RightRotOffset = RightRenderPlane.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        LeftRenderPlane.transform.position = TrackHeadObj.position + LeftPosOffset;
        LeftRenderPlane.transform.rotation = TrackHeadObj.rotation ;
        RightRenderPlane.transform.position = TrackHeadObj.position + RightPosOffset;
        RightRenderPlane.transform.rotation = TrackHeadObj.rotation ;
    }
}
