using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;

public class LookAtCam : MonoBehaviour
{
    MeshRenderer mMeshRenderer;
    public GameObject target;
 
    //private void Start()
    //{
    //    mMeshRenderer = this.GetComponent<MeshRenderer>();
    //    mMeshRenderer.enabled = false;
    //}

    // Update is called once per frame
    void Update()
    {
        if (TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World).GazeRay.IsValid)
        {
            mMeshRenderer.enabled = true;
        }
        else { mMeshRenderer.enabled = false; }
    }

    private void OnEnable()
    {
        mMeshRenderer = this.GetComponent<MeshRenderer>();
        mMeshRenderer.enabled = false;
    }

    private void OnDisable()
    {
        TobiiXR.Stop();
    }
}
