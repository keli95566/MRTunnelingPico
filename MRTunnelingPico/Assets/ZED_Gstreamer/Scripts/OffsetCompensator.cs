using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetCompensator : MonoBehaviour
{
    // offset Vector is obtained from the calibration application

    public Vector3 offsetVector = new Vector3(0.00999998f, -0.0048f, -0.0052f);

    private Vector3 offset = new Vector3(0.00999998f, -0.0048f, -0.0052f);
    public Transform zedRightFrame;
    public Transform zedLeftFrame;

    private bool compensated = false;
    private Vector3 startPosRight;
    private Vector3 startPosLeft;

    private bool ready;

    // Start is called before the first frame update

    void Start()
    {
        startPosRight = zedRightFrame.position;
        startPosLeft = zedLeftFrame.position;

    }

    private void Awake()
    {


    }



    private void Ready()
    {
        ready = true;

    }
    // Update is called once per frame
    void Update()
    {
        //hard code it for now          
        //Vector3 orgVec = new Vector3(0.008671926f, -0.00234738f, 0.15f);

        if (compensated == false && ready )
        {
            Vector3 oldLeftPos = zedLeftFrame.position;
            Vector3 oldRightPos = zedRightFrame.position;

            zedLeftFrame.position = oldLeftPos + offsetVector;
            zedRightFrame.position = oldRightPos + offsetVector;

            compensated = true;

        }
    }
}
