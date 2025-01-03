using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("- GameObject")]
    public GameObject mainPage;
    public GameObject playPage;

    [Header("- playPage Script")]
    public VideoManager videoManager;
    public SurveyManager surveyManager;
    public CaptureManager captureManager;
    public DrawPLManager drawPLManager;
    public DrawPoints drawPoints;
    public DrawLines drawLines;
    public TimeRecorder timeRecorder;
    public WriteToCSVFile WriteToCSVFile;
    public EyeBlinking eyeBlinking;

    [Header("- playPage OBJ")]
    public GameObject survayCanvasGroup;
    public GameObject imageProcessing;
    public GameObject eyeTrackerData;

    [Header("- GUI")]
    public Button goToMain;
    public Button goToPlay;
    public Dropdown dropDown;
    public Button goToStress;

    [Header("- Player GUI")]
    public GameObject exitButtonObj;
    public Button exitButton;

    public static bool sign = false;

    public void ChangeScene_GoToStress()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeScene_GoToCalibration()
    {
        SceneManager.LoadScene(2);
    }

    public enum GameState
    {
        None,
        MainPage,
        PlayPage
    }

    public static GameState gameState = GameState.MainPage;

    // Start is called before the first frame update
    void Start()
    {
        mainPage.SetActive(true);
        playPage.SetActive(true);

        sign = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.None:
                break;

            case GameState.MainPage:
                if (sign == false)
                {
                    Debug.Log("mainPage!");
                    
                    goToMain.interactable = false;
                    goToPlay.interactable = true;
                    dropDown.interactable = true;
                    goToStress.interactable = true;
                    
                    mainPage.SetActive(true);
                    playPage.SetActive(false);

                    sign = true;
                }
                break;

            case GameState.PlayPage:
                if (sign == true)
                {
                    Debug.Log("playPage!");

                    goToMain.interactable = true;
                    goToPlay.interactable = false;
                    dropDown.interactable = false;
                    goToStress.interactable = false;


                    mainPage.SetActive(false);
                    playPage.SetActive(true);

                    StartCoroutine("SignChange");
                }
                break;
        }
    }

    IEnumerator SignChange()
    {
        yield return new WaitForSeconds(0.02f);
        sign = false;
        StopAllCoroutines();
    }

    public void ExitButton()
    {
        exitButtonObj.SetActive(false);
        ViveControllerInput.sign = false;
        gameState = GameState.MainPage;
    }
}
