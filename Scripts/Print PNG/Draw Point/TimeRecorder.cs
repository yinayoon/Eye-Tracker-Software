using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRecorder : MonoBehaviour
{
    public static float timeSpan; // 경과한 시간을 갖는 변수
    public static float checkTime; // 특정 시간을 갖는 변수
    public static List<int> idx = new List<int>();

    void Update()
    {
        if (TobiiManager.gazeRaySign == true)
        {
            timeSpan += Time.deltaTime; //  경과 시간을 계속 등록

            if (timeSpan > checkTime) // 경과 시간이 특정 시간 보다 커졌을 경우 
            {
                DrawPoints.colorChangeSign = true;
                timeSpan = 0;
            }
        }
    }

    private void OnDisable()
    {
        timeSpan = 0;
    }

    private void OnEnable()
    {
        timeSpan = 0.0f;
        checkTime = 5f;
    }
}
