using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Tobii.XR;

public class DataManager : MonoBehaviour
{
    string timeSpanding;
    float timeNum;
    public static bool headOnOff;
    public Text dataText;

    List<Vector3> distanceVec = new List<Vector3>();

    public static List<float> distanceFloat = new List<float>();
    public static List<string> objNameList = new List<string>();
    public static List<string> timeNumList = new List<string>();
    public static string objNameText;
    public static string timeNumText;

    int idx;

    // Start is called before the first frame update
    //void Start()
    //{
    //    headOnOff = false;
    //    blinkLeftNum = 0;
    //    blinkRightNum = 0;
    //    idx = 0;
    //    timeNum = 0;
    //
    //    StartCoroutine("delayTime");
    //    distanceVec.Add(TobiiManager.ray);
    //}

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sign == true && GameManager.gameState == GameManager.GameState.PlayPage)
        {
            Initialization();
            Debug.Log("초기화!");
        }
    }

    IEnumerator delayTime()
    {
        while (true)
        {
            while (TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World).GazeRay.IsValid && VideoManager.signOfEyetracking == true)
            {
                distanceVec.Add(TobiiManager.ray);

                if (idx > 1)
                {
                    distanceFloat.Add(Vector3.Distance(distanceVec[idx], distanceVec[idx + 1]));
                    //Debug.Log("이동 거리 : " + distanceFloat[idx]);
                }

                idx++;
                timeNum += 0.2f;

                //Debug.Log("경과 시간 : " + Math.Truncate(timeNum * 10) / 10);
                timeNumList.Add((Math.Truncate(timeNum * 10) / 10).ToString());

                if (RayInteractionHuman.humanDetect == true)
                {
                    Debug.Log("검출 : " + RayInteractionHuman.humanText);
                    dataText.text = RayInteractionHuman.humanText;
                    objNameList.Add(RayInteractionHuman.humanText);
                }
                else if (RayInteractionHuman.humanDetect == false)
                {
                    Debug.Log("검출 : " + RayInteraction.objText);
                    dataText.text = RayInteraction.objText;
                    objNameList.Add(RayInteraction.objText);
                }
                else
                {
                    dataText.text = "";
                }

                yield return new WaitForSeconds(0.2f);
            } yield return new WaitForSeconds(0.2f);
        }
    }

    private void Initialization()
    {
        Debug.Log("초기화!");

        StopAllCoroutines();
        headOnOff = false;
        idx = 0;
        timeNum = 0;

        distanceFloat = new List<float>();
        objNameList = new List<string>();
        timeNumList = new List<string>();

        StartCoroutine("delayTime");
        distanceVec.Add(TobiiManager.ray);
    }

    private void OnDisable()
    {
        TobiiXR.Stop();
    }
}