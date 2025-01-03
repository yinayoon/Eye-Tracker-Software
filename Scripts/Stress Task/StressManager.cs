using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StressManager : MonoBehaviour
{
    [Header("- User Viewer")]
    public Text _title;
    public Text _modification;
    public Text _questionMark;
    public Text _correctPercent;
    public Text _allTestTime;
    public Text _concludeQustion;

    [Header ("- Input Field")]
    public InputField allNumInput;
    public InputField minusNum;
    public Text allNumText;
    public Text minusNumText;
    public Text correctNum;
    public Text[] correctNumList;

    [Header("- Button Field")]
    public Button play;
    public Button stop;
    public Button buttonO;
    public Button buttonX;
    public Text remainTime;
    public Text correctPercent;
    public Text allTestTime;

    [Header("- Time Field")]
    public int time;

    // Private Field
    float CurrTime;
    float passTime;
    bool signO;
    bool signX;
    bool sign;
    bool signStart;
    int clickNum;
    int correctClickNum;
    Queue<int> minusList = new Queue<int>();
    int _originNum;
    int _minusNum;
    int minusConclude;
    float _Sec;
    int _Min;

    // enum Field
    enum StressTaskState
    {
        Idle,
        Play,
        Stop
    }

    StressTaskState stressTaskState = StressTaskState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        stressTaskState = StressTaskState.Idle;

        minusConclude = 0;

        signO = false;
        signX = false;
        sign = true;
        signStart = false;

        _originNum = 0;
        _minusNum = 0;

        _title.text = _originNum + "에서 " + _minusNum + "씩 반복해서 빼주세요.";
        _modification.text = _originNum + " - " + _minusNum + " = ";

        clickNum = 0;
        correctClickNum = 0;

        MinusGameInitialize();
    }

    // Update is called once per frame
    void Update()
    {        
        switch (stressTaskState)
        {
            case StressTaskState.Idle:

                minusConclude = _originNum;
                MinusFunc();

                StopAllCoroutines();
                _correctPercent.text = "0 %";
                correctPercent.text = "0 %";
                _allTestTime.text = "00:00";
                remainTime.text = "00:00";
                _modification.color = Color.black;
                _questionMark.color = Color.black;
                _concludeQustion.color = Color.black;
                _concludeQustion.text = "";
                _Sec = 0;
                _Min = 0;
                CurrTime = 0;
                buttonO.interactable = false;
                buttonX.interactable = false;

                stressTaskState = StressTaskState.Stop;
                break;

            case StressTaskState.Stop:

                allNumInput.interactable = true;
                minusNum.interactable = true;

                signO = false;
                signX = false;
                sign = true;
                signStart = true;

                clickNum = 0;
                correctClickNum = 0;
                break;

            case StressTaskState.Play:
                allNumInput.interactable = false;
                minusNum.interactable = false;

                _allTestTime.text = Timer(3);
                remainTime.text = _allTestTime.text;
                PlayBasedFunc();
                _correctPercent.text = CorrectPercentFunc() + "%";
                correctPercent.text = _correctPercent.text;

                if (signStart == true)
                {
                    buttonO.interactable = true;
                    buttonX.interactable = true;

                    minusConclude = _originNum;
                    MinusFunc();
                    StartCoroutine("PlayStart");
                    signStart = false;
                }

                _Sec += Time.deltaTime;
                allTestTime.text = string.Format("{0:D2}:{1:D2}", _Min, (int)_Sec);

                if((int)_Sec > 59)
                {
                    _Sec = 0;
                    _Min++;
                }

                break;
        }
    }

    IEnumerator PlayStart()
    {
        for (int i = 0; i < time; i++)
        {
            //Debug.Log(i);
            yield return new WaitForSeconds(1);
        }
        stressTaskState = StressTaskState.Idle;
    }

    public void MinusGameInitialize()
    {
        minusList.Clear();
        minusConclude = _originNum;

        MinusFunc();
    }

    public string Timer(float _limitTime) // 시간 경과 로직 구현
    {
        float num = _limitTime;
        string str;

        CurrTime += Time.deltaTime;
        passTime = num - CurrTime;

        if ((num - CurrTime) > 0)
        {
            str = (num - CurrTime).ToString("00.00").Replace(".", ":");
            remainTime.text = str;
            if ((num - CurrTime) < 1 && sign == true)
            {
                StartCoroutine("ColorChange");
                sign = false;
            }
        }
        else
        {
            str = "00:00"; CurrTime = 0;
            remainTime.text = str;
        }
        return str;
    }

    public string CorrectPercentFunc() // 정답 오답률 메소드
    {
        if(clickNum <= 0)
        {
            return "0";
        }

        int percent;

        percent = (correctClickNum * 100) / clickNum; // 정답률 공식 적용 코드
        return percent.ToString();
    }

    public void PlayBasedFunc() // 기반이 되는 로직 메소드
    {
        if (passTime > 0) // 0이 되기전에
        {
            if (signO == true && signX == false) // 정답을 맞췄다면
            {
                CurrTime = 0;
                clickNum++;
                correctClickNum++;

                MinusFunc();

                ChangeTextColorInitialize();

                sign = true;
                signO = false;
            }
            else if (signX == true && signO == false) // 정답을 못 맞췄다면
            {
                CurrTime = 0;
                clickNum++;

                // 리스트 초기화
                minusList.Clear();

                minusConclude = _originNum;

                MinusFunc();

                ChangeTextColorInitialize();

                sign = true;
                signX = false;
            }
        }
        else // 0이 된 후에
        {
            signO = false;
            signX = false;
            sign = true;
            clickNum++;
            // 리스트 초기화
            minusList.Clear();

            minusConclude = _originNum;

            MinusFunc();

            ChangeTextColorInitialize();

            _concludeQustion.color = Color.red;
            StartCoroutine(PrintConclude("시간이 초과되었습니다."));
            //Debug.Log("시간이 초과되었습니다.");
        }
    }

    public void MinusFunc()
    {
        minusList.Enqueue(minusConclude -= _minusNum);

        correctNumList[0].text = minusList.Dequeue().ToString();
        Debug.Log(minusConclude);
        //Debug.Log(minusList[minusList.Count - 1]);

        int num = minusConclude;
        for (int i = 1; i < correctNumList.Length; i++)
        {
            correctNumList[i].text = (num -= _minusNum).ToString();
            //Debug.Log(minusList[i].ToString());
        }
    }

    // 자극 실행 버튼
    public void TaskPlay()
    {
        stressTaskState = StressTaskState.Play;
    }

    // 자극 정지 버튼
    public void TaskStop()
    {
        stressTaskState = StressTaskState.Idle;
    }

    // 버튼 O
    public void ButtonO()
    {
        signO = true;
        signX = false;
        sign = true;

        _concludeQustion.color = Color.green;
        StartCoroutine(PrintConclude("정답입니다."));

        //Debug.Log("정답입니다.");
    }

    // 버튼 X
    public void ButtonX()
    {
        signO = false;
        signX = true;
        sign = true;

        _concludeQustion.color = Color.red;
        StartCoroutine(PrintConclude("오답입니다."));

        //Debug.Log("오답입니다.");
    }

    // 인풋 필드 입력 (전체 수 입력)
    public void InputAllNumInput(string value)
    {
        _originNum = int.Parse(value);
        MinusNumFunc();
        //Debug.Log(_originNum);
    }

    // 인풋 필드 입력 (빼는 수 입력)
    public void InputMinusNumInput(string value)
    {
        _minusNum = int.Parse(value);
        MinusNumFunc();
        //Debug.Log(_minusNum);
    }

    // 뺄샘 함수
    public void MinusNumFunc()
    {
        _title.text = _originNum + "에서 " + _minusNum + "씩 반복해서 빼주세요.";
        _modification.text = _originNum + " - " + _minusNum + " = ";

        MinusGameInitialize();
    }

    // Text 색 변화
    IEnumerator ColorChange()
    {
        for (int i = 0; i <= 14; i++)
        {
            _modification.color = Color.red;
            _questionMark.color = Color.red;
            yield return new WaitForSeconds(0.05f);
            _modification.color = Color.black;
            _questionMark.color = Color.black;
            yield return new WaitForSeconds(0.05f);
        }
        _concludeQustion.text = "";
    }

    // 글자 색 변화 초기화
    public void ChangeTextColorInitialize()
    {
        StopCoroutine("ColorChange");
        _modification.color = Color.black;
        _questionMark.color = Color.black;
    }

    // 정답 결과 출력
    IEnumerator PrintConclude(string str)
    {
        _concludeQustion.text = str;
        yield return new WaitForSeconds(1);
        _concludeQustion.color = Color.black;
        _concludeQustion.text = "";
    }

    // 콘텐츠로 이동
    public void GoToExperiment()
    {
        SceneManager.LoadScene("Software Scene");
    }
}
