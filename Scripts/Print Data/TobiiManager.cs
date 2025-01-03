using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.XR;

public class TobiiManager : MonoBehaviour
{
    public GameObject eyeTarget;
    public bool eyeTargetOnOff;

    public static Vector3 rayOrigin;
    public static Vector3 rayDirection;
    public static Vector3 ray;
    public static Vector3 eyesDirection;
    public static bool isLeftEyeBlinking;
    public static bool isRightEyeBlinking;

    public static bool gazeRaySign;
    public static bool BlinkingSign;

    void Start()
    {
        var settings = new TobiiXR_Settings();
        TobiiXR.Start(settings);
    
        isLeftEyeBlinking = false;
        isRightEyeBlinking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameState == GameManager.GameState.MainPage)
        {
            eyeTarget.SetActive(false);
        }
        else if(GameManager.gameState == GameManager.GameState.PlayPage)
        {
            eyeTarget.SetActive(true);
        }

        Vector3 direction = Camera.main.transform.position - eyeTarget.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        eyeTarget.transform.rotation = targetRotation;

        // Get eye tracking data in world space
        var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);

        if (TobiiXR.FocusedObjects.Count > 0) // 만약 Count가 하나이상이라면
        {
            // The object being focused by the user, determined by G2OM.
            var focusedObject = TobiiXR.FocusedObjects[0];
        }

        // Check if gaze ray is valid
        if (eyeTrackingData.GazeRay.IsValid)
        {
            gazeRaySign = true;
            // The origin of the gaze ray is a 3D point
            rayOrigin = eyeTrackingData.GazeRay.Origin;

            // The direction of the gaze ray is a normalized direction vector
            rayDirection = eyeTrackingData.GazeRay.Direction;
            ray = rayOrigin + rayDirection;

            eyeTarget.transform.position = ray;

            // The EyeBlinking bool is true when the eye is closed
            isLeftEyeBlinking = eyeTrackingData.IsLeftEyeBlinking;
            isRightEyeBlinking = eyeTrackingData.IsRightEyeBlinking;

            // Using gaze direction in local space makes it easier to apply a local rotation
            // to your virtual eye balls.
            eyesDirection = eyeTrackingData.GazeRay.Direction;

            if (eyeTrackingData.IsLeftEyeBlinking == true && eyeTrackingData.IsRightEyeBlinking == true)
            {
                BlinkingSign = true;
            }
            else
            {
                BlinkingSign = false;
            }

            if (GameManager.gameState == GameManager.GameState.PlayPage && eyeTargetOnOff == true)
            {
                eyeTarget.GetComponent<MeshRenderer>().enabled = true;
                eyeTarget.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                eyeTarget.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().enabled = true;
            }
            else
            {
                eyeTarget.GetComponent<MeshRenderer>().enabled = false;
                eyeTarget.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                eyeTarget.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().enabled = false;
            }
        }
        else
        {
            gazeRaySign = false;
            BlinkingSign = false;
        }
    }        
}