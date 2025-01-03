using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;

public class MyBootstrapper : MonoBehaviour
{
    //public GameObject trackModel;
    public float distance = 100;

    private void Update()
    {
        // Get eye tracking data in world space
        var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);

        if (TobiiXR.FocusedObjects.Count > 0) // 만약 Count가 하나이상이라면
        {
            // The object being focused by the user, determined by G2OM.
            var focusedObject = TobiiXR.FocusedObjects[0];
            //Debug.Log(TobiiXR.FocusedObjects[0].GameObject.name);
        }

        // Check if gaze ray is valid
        if (eyeTrackingData.GazeRay.IsValid)
        {
            //gazeRaySign = true;

            // The origin of the gaze ray is a 3D point
            Vector3 rayOrigin = eyeTrackingData.GazeRay.Origin;

            // The direction of the gaze ray is a normalized direction vector
            Vector3 rayDirection = eyeTrackingData.GazeRay.Direction;
            Vector3 ray = rayOrigin + rayDirection;
        }
    }
}