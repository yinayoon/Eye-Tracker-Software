using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Diagnostics;

public class SurveyManager : MonoBehaviour
{
    [Header("- Canvas Group")]
    public GameObject startCanvas;
    public GameObject surveyCanvas;

    [Header("- GUI GameObject")]
    public GameObject canvas;
    public GameObject panel;
    public GameObject question;
    public GameObject[] answerButton;
    public GameObject nextButton;
    public GameObject collectNum;

    [Header("- GUI Button")]
    public Button printButton;

    [Header("- Question Text")]
    public string[] questionStr;
    
    [Header("- Answer Text")]
    [SerializeField]
    public SubArray[] answer;

    [Serializable]
    public class SubArray
    {
        [SerializeField]
        public bool five;
        public bool seven;
        public bool nine;
        public bool eleven;
        public string[] answerStr;
    }

    [Header("- Survey Csc Print")]
    public SurveyCscPrint surveyCscPrint;

    [Header("- Write Eyetracking Data To CSV File")]
    public WriteToCSVFile writeToCSVFile;

    private int answerIdx;
    private int collectAnswer;
    public static int[] answerConclude;
    private bool clickSign;

    // Update is called once per frame
    void Update()
    {
        if(clickSign == true) { nextButton.GetComponent<Button>().interactable = true; }
        else { nextButton.GetComponent<Button>().interactable = false; }
    }

    public void NextButtonFunc()
    {
        if (answerIdx >= 0 && answerIdx < questionStr.Length)
        {            
            answerConclude[answerIdx] = collectAnswer;
            answerIdx++;

            if (answerIdx < questionStr.Length) {
                if(answerIdx == questionStr.Length - 1) 
                {
                    nextButton.transform.GetChild(0).GetComponent<Text>().text = "Print Cvs"; 
                }

                question.GetComponent<Text>().text = questionStr[answerIdx];
                for (int i = 0; i < answerButton.Length; i++) { answerButton[i].transform.GetChild(0).GetComponent<Text>().text = answer[answerIdx].answerStr[i]; }                
            }

            if (answerIdx == questionStr.Length)
            {
                surveyCscPrint.addRecordButton();
                writeToCSVFile.addRecordButton();
                printButton.onClick.Invoke();

                for (int i = 0; i < answerButton.Length; i++) { answerButton[i].GetComponent<Button>().interactable = false; }

                collectNum.GetComponent<Text>().text = "";
                question.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                question.transform.position = new Vector3(0, 0.9f, 3.5f);
                question.GetComponent<Text>().text = "설문 종료";

                GameManager.gameState = GameManager.GameState.MainPage;

                return;
            }

            GUISetting();

            clickSign = false;
        }
    }

    public void CollectAnswer()
    {        
        
    }

    public void Click(int value)
    {
        clickSign = true;

        if (value == 0) { collectNum.GetComponent<Text>().text = "Selection : 1"; collectAnswer = 1; }
        else if (value == 1) { collectNum.GetComponent<Text>().text = "Selection : 2"; collectAnswer = 2; }
        else if (value == 2) { collectNum.GetComponent<Text>().text = "Selection : 3"; collectAnswer = 3; }
        else if (value == 3) { collectNum.GetComponent<Text>().text = "Selection : 4"; collectAnswer = 4; }
        else if (value == 4) { collectNum.GetComponent<Text>().text = "Selection : 5"; collectAnswer = 5; }
        else if (value == 5) { collectNum.GetComponent<Text>().text = "Selection : 6"; collectAnswer = 6; }
        else if (value == 6) { collectNum.GetComponent<Text>().text = "Selection : 7"; collectAnswer = 7; }
        else if (value == 7) { collectNum.GetComponent<Text>().text = "Selection : 8"; collectAnswer = 8; }
        else if (value == 8) { collectNum.GetComponent<Text>().text = "Selection : 9"; collectAnswer = 9; }
        else if (value == 9) { collectNum.GetComponent<Text>().text = "Selection : 10"; collectAnswer = 10; }
        else if (value == 10) { collectNum.GetComponent<Text>().text = "Selection : 11"; collectAnswer = 11; }
    }

    public void StartSurvay()
    {
        startCanvas.SetActive(false);
        surveyCanvas.SetActive(true);
    }

    private void OnEnable()
    {
        clickSign = false;

        collectAnswer = 0;
        answerIdx = 0;
        answerConclude = new int[questionStr.Length];

        question.GetComponent<Text>().text = questionStr[answerIdx];
        for (int i = 0; i < answerButton.Length; i++)
        {
            answerButton[i].transform.GetChild(0).GetComponent<Text>().text = answer[answerIdx].answerStr[i];
            answerButton[i].GetComponent<Button>().interactable = true;
        }

        startCanvas.SetActive(true);
        surveyCanvas.SetActive(false);

        collectNum.SetActive(true);
        question.transform.localPosition = new Vector3(-1, 0.9f, 0);
        question.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        collectNum.GetComponent<Text>().text = "Selection : ";

        nextButton.transform.GetChild(0).GetComponent<Text>().text = "Next";

        GUISetting();
    }

    public void GUISetting()
    {
        for (int j = 0; j < answerButton.Length; j++) { answerButton[j].SetActive(false); }

        if (answer[answerIdx].five == true)
        {
            for (int j = 0; j < answerButton.Length - 6; j++)
            {
                answerButton[j].SetActive(true);
            }

            nextButton.transform.localPosition = new Vector3(0, -0.9f, 0);
        }
        else if (answer[answerIdx].seven == true)
        {
            for (int j = 0; j < answerButton.Length - 4; j++)
            {
                answerButton[j].SetActive(true);
            }

            nextButton.transform.localPosition = new Vector3(0, -1.4f, 0);
        }
        else if (answer[answerIdx].nine == true)
        {
            for (int j = 0; j < answerButton.Length - 2; j++)
            {
                answerButton[j].SetActive(true);
            }

            nextButton.transform.localPosition = new Vector3(0, -1.9f, 0);
        }
        else if (answer[answerIdx].eleven == true)
        {
            for (int j = 0; j < answerButton.Length; j++)
            {
                answerButton[j].SetActive(true);
            }

            nextButton.transform.localPosition = new Vector3(0, -2.4f, 0);
        }
    }
}
