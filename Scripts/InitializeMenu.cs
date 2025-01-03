using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeMenu : MonoBehaviour
{
    public int lineNum;
    public int buttonNum;
    public GameObject[] PanelGroups = new GameObject[4];
    public GameObject[] buttons = new GameObject[20];
    public GameObject SelectButton;

    public static int stimulationNum;

    private void Awake()
    {
        stimulationNum = buttonNum;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PanelGroups.Length; i++) { PanelGroups[i].SetActive(false); }
        for (int i = 0; i < buttons.Length; i++) { buttons[i].SetActive(false); }

        switch (lineNum)
        {
            case 0:
                break;
            case 1:
                for (int i = 0; i < PanelGroups.Length - 3; i++) { PanelGroups[i].SetActive(true); }
                SelectButton.transform.localPosition = new Vector3(1.2f, -0.363f, 0);
                break;
            case 2:
                for (int i = 0; i < PanelGroups.Length - 2; i++) { PanelGroups[i].SetActive(true); }
                SelectButton.transform.localPosition = new Vector3(1.2f, -0.863f, 0);
                break;
            case 3:
                for (int i = 0; i < PanelGroups.Length - 1; i++) { PanelGroups[i].SetActive(true); }
                SelectButton.transform.localPosition = new Vector3(1.2f, -1.363f, 0);
                break;
            case 4:
                for (int i = 0; i < PanelGroups.Length; i++) { PanelGroups[i].SetActive(true); }
                SelectButton.transform.localPosition = new Vector3(1.2f, -1.863f, 0);
                break;
            default:
                break;
        }

        switch (buttonNum)
        {
            case 0:
                for (int i = 0; i < buttons.Length - 20; i++) { buttons[i].SetActive(true); }
                break;
            case 1:
                for (int i = 0; i < buttons.Length - 19; i++) { buttons[i].SetActive(true); }
                break;
            case 2:
                for (int i = 0; i < buttons.Length - 18; i++) { buttons[i].SetActive(true); }
                break;
            case 3:
                for (int i = 0; i < buttons.Length - 17; i++) { buttons[i].SetActive(true); }
                break;
            case 4:
                for (int i = 0; i < buttons.Length - 16; i++) { buttons[i].SetActive(true); }
                break;
            case 5:
                for (int i = 0; i < buttons.Length - 15; i++) { buttons[i].SetActive(true); }
                break;
            case 6:
                for (int i = 0; i < buttons.Length - 14; i++) { buttons[i].SetActive(true); }
                break;
            case 7:
                for (int i = 0; i < buttons.Length - 13; i++) { buttons[i].SetActive(true); }
                break;
            case 8:
                for (int i = 0; i < buttons.Length - 12; i++) { buttons[i].SetActive(true); }
                break;
            case 9:
                for (int i = 0; i < buttons.Length - 11; i++) { buttons[i].SetActive(true); }
                break;
            case 10:
                for (int i = 0; i < buttons.Length - 10; i++) { buttons[i].SetActive(true); }
                break;
            case 11:
                for (int i = 0; i < buttons.Length - 9; i++) { buttons[i].SetActive(true); }
                break;
            case 12:
                for (int i = 0; i < buttons.Length - 8; i++) { buttons[i].SetActive(true); }
                break;
            case 13:
                for (int i = 0; i < buttons.Length - 7; i++) { buttons[i].SetActive(true); }
                break;
            case 14:
                for (int i = 0; i < buttons.Length - 6; i++) { buttons[i].SetActive(true); }
                break;
            case 15:
                for (int i = 0; i < buttons.Length - 5; i++) { buttons[i].SetActive(true); }
                break;
            case 16:
                for (int i = 0; i < buttons.Length - 4; i++) { buttons[i].SetActive(true); }
                break;
            case 17:
                for (int i = 0; i < buttons.Length - 3; i++) { buttons[i].SetActive(true); }
                break;
            case 18:
                for (int i = 0; i < buttons.Length - 2; i++) { buttons[i].SetActive(true); }
                break;
            case 19:
                for (int i = 0; i < buttons.Length - 1; i++) { buttons[i].SetActive(true); }
                break;
            case 20:
                for (int i = 0; i < buttons.Length; i++) { buttons[i].SetActive(true); }
                break;
            default:
                break;
        }
    }
}
