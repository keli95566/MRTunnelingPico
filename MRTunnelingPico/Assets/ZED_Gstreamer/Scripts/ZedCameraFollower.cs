using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZedCameraFollower : MonoBehaviour
{
    public Transform ZedCameraRigTransform;
    public float forwardOffset = 0;
    public float backwardOfset = 0;
    public float leftOffset = 0;
    public float rightOffset = 0;
    public float upOffset = 0;
    public float downOffset = 0;


    Vector3[] initialTransform;
    Quaternion[] initialRot;
    void Start()
    {

        initialTransform = new Vector3[transform.childCount];
        initialRot = new Quaternion[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            Vector3 initialPos = child.position;
            initialTransform[i] = initialPos;
            initialRot[i] = child.rotation;

            i += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int counter = 0;
        foreach (Transform child in transform)
        {

            child.position = initialTransform[counter] + ZedCameraRigTransform.position + Vector3.forward * forwardOffset + Vector3.back * backwardOfset + Vector3.left * leftOffset + Vector3.right * rightOffset + Vector3.up * upOffset + Vector3.down * downOffset;
            // rotate relative to zed camera
            child.rotation = ZedCameraRigTransform.rotation*initialRot[counter];
            counter += 1;
        }
    }
}
