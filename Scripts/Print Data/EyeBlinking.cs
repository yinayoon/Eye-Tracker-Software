using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class EyeBlinking : MonoBehaviour
{
    bool leftBoolSign;
    bool rightBoolSign;

    int leftBlinkNum;
    int rightBlinkNum;

    public static string leftBlink;
    public static string rightBlink;

    // 헤드셋 입력 소스
    public SteamVR_Input_Sources head = SteamVR_Input_Sources.Head;
    // 액션 - 헤드셋의 착용 여부
    public SteamVR_Action_Boolean headSet = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("HeadsetOnHead", true);

    // Start is called before the first frame update
    //void Start()
    //{
    //    leftBoolSign = false;
    //    rightBoolSign = false;
    //
    //    leftBlinkNum = 0;
    //    rightBlinkNum = 0;
    //
    //    leftBlink = leftBlinkNum.ToString();
    //    rightBlink = rightBlinkNum.ToString();
    //
    //    StartCoroutine("delay");
    //}

    IEnumerator delay()
    {
        while (true)
        {
            if (headSet.GetState(head))
            {
                if (TobiiManager.isLeftEyeBlinking == true && leftBoolSign == false)
                {
                    leftBoolSign = true;
                    leftBlinkNum++;
                    leftBlink = leftBlinkNum.ToString();
                }
                else if (TobiiManager.isLeftEyeBlinking == false && leftBoolSign == true)
                {
                    leftBoolSign = false;
                }

                if (TobiiManager.isRightEyeBlinking == true && rightBoolSign == false)
                {
                    rightBoolSign = true;
                    rightBlinkNum++;
                    rightBlink = rightBlinkNum.ToString();
                }
                else if (TobiiManager.isRightEyeBlinking == false && rightBoolSign == true)
                {
                    rightBoolSign = false;
                }
                yield return new WaitForSeconds(0.2f);
            }
            else { yield return new WaitForSeconds(0.2f); }
        }
    }

    private void OnEnable()
    {
        leftBoolSign = false;
        rightBoolSign = false;
    
        leftBlinkNum = 0;
        rightBlinkNum = 0;
    
        leftBlink = leftBlinkNum.ToString();
        rightBlink = rightBlinkNum.ToString();
    
        StartCoroutine("delay");
    }
}
