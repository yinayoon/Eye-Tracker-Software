using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ViveControllerInput : MonoBehaviour
{
    // 입력 소스 정의
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    public SteamVR_Input_Sources any = SteamVR_Input_Sources.Any;
    // 헤드셋의 입력 소스
    public SteamVR_Input_Sources head = SteamVR_Input_Sources.Head;

    // 액션 - 트리거 버튼 (InteractUI)
    private SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    // 액션 - 트랙패드 클릭 버튼 (Teleport)
    public SteamVR_Action_Boolean trackPad = SteamVR_Actions.default_Teleport;
    // 액션 - 트랙패드 터치 여부 (TrackPadTouch)
    public SteamVR_Action_Boolean trackPadTouch = SteamVR_Actions.default_TrackPadTouch;
    // 액션 - 트랙패드 터치 좌표 (TarckPadPosition)
    public SteamVR_Action_Vector2 trackPadPosition = SteamVR_Actions.default_TrackPadPosition;

    // 액션 - 그립 버튼의 잡기 (GrabGrip)
    public SteamVR_Action_Boolean grip = SteamVR_Input.GetBooleanAction("GrabGrip");
    // 액션 - 햅틱 (Haptic)
    public SteamVR_Action_Vibration haptic = SteamVR_Actions.default_Haptic;
    // 액션 - 헤드셋의 착용 여부
    public SteamVR_Action_Boolean headSet = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("HeadsetOnHead", true);

    public SteamVR_Action_Boolean Trigger { get => trigger; set => trigger = value; }

    [Header("- Player GUI")]
    public GameObject exitButtonObj;
    public Button exitButton;
    public static bool sign;

    private void Start()
    {
        exitButtonObj.SetActive(false);
        sign = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Vive 장비의 초기화 여부 확인
        if (SteamVR.initializedState != SteamVR.InitializedStates.InitializeSuccess)
        {
            return;
        }

        if (headSet.GetStateDown(head)) // 헤드셋을 착용
        {
            //Debug.Log("Headset on");
        }
        else if (headSet.GetStateUp(head)) // 헤드셋을 미착용
        {
            //Debug.Log("Headset removed");
        }

        // 왼손 컨트롤러의 트리거 버튼을 클릭했을 경우
        if (trackPadTouch.GetState(any))
        {
            Vector2 pos = trackPadPosition.GetAxis(any);
            //Debug.LogFormat("Touch Position = {0}", pos);
        }

        // 오른손 컨트롤러의 그립을 잡았을 경우
        if (grip.GetStateDown(rightHand))
        {
            //Debug.Log("Right Grip button");
            // 오른손 컨트롤러에 진동을 발생시킴
            haptic.Execute(0.2f, 0.2f, 50.0f, 0.5f, rightHand);
        }

        if (trackPad.GetStateDown(any) && GameManager.gameState == GameManager.GameState.PlayPage)
        {
            if (sign == false)
            {
                exitButtonObj.SetActive(true);
                sign = true;
            }
            else
            {
                exitButtonObj.SetActive(false);
                sign = false;
            }
        }
    }
}
