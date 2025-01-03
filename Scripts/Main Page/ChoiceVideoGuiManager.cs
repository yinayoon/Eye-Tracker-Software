using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceVideoGuiManager : MonoBehaviour
{
    [Header ("- Game Object")]
    public GameObject titleGroup;
    public GameObject[] UIGroup;

    [Header("- Text")]
    public Text choiceText;
    public Text resultText;

    [Header("- Font")]
    public Font[] NEXONFontStyle;

    [Header("- Button")]
    public Button[] videoButton;
    public Button sellectButton;

    [Header("- Randerer")]
    public Texture beginningSkyBox;
    public Texture[] bg360 = new Texture[20];
    public MeshRenderer choiceMaterial;

    public static bool[] videoPlaySign;

    // Start is called before the first frame update
    void Start()
    {
        bg360 = new Texture[20];
    
        for (int i = 0; i < bg360.Length; i++)
        {
            bg360[i] = Resources.Load<Texture>(Convert.ToChar(65 + i).ToString() + "_Image");
        }
    
        //===================================================================================//
    
        choiceMaterial.material.SetTexture("_MainTex", beginningSkyBox);

        videoPlaySign = new bool[videoButton.Length];
        for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
        sellectButton.interactable = false;
        titleGroup.SetActive(true);
    
        //===================================================================================//
    
        for (int i = 0; i < videoButton.Length; i++) { videoButton[i].interactable = true; }
    
        choiceText.font = NEXONFontStyle[2];
        resultText.font = NEXONFontStyle[2];
    
        choiceText.color = Color.white;
        resultText.color = Color.white;
    
        resultText.text = "";
    
        titleGroup.transform.localPosition = new Vector3(-0.75f, 0.3f, 0);
    
        for (int i = 0; i < UIGroup.Length; i++)
        {
            UIGroup[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChiceButton(string text)
    {
        resultText.text = text;
    }

    public void ChangeImage(int num)
    {
        switch(num) {
            case 0:
                choiceMaterial.material.SetTexture("_MainTex", bg360[0]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[0] = true;
                sellectButton.interactable = true;
                break;
            case 1:
                choiceMaterial.material.SetTexture("_MainTex", bg360[1]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[1] = true;
                sellectButton.interactable = true;
                break;
            case 2:
                choiceMaterial.material.SetTexture("_MainTex", bg360[2]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[2] = true;
                sellectButton.interactable = true;
                break;
            case 3:
                choiceMaterial.material.SetTexture("_MainTex", bg360[3]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[3] = true;
                sellectButton.interactable = true;
                break;
            case 4:
                choiceMaterial.material.SetTexture("_MainTex", bg360[4]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[4] = true;
                sellectButton.interactable = true;
                break;
            case 5:
                choiceMaterial.material.SetTexture("_MainTex", bg360[5]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[5] = true;
                sellectButton.interactable = true;
                break;
            case 6:
                choiceMaterial.material.SetTexture("_MainTex", bg360[6]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[6] = true;
                sellectButton.interactable = true;
                break;
            case 7:
                choiceMaterial.material.SetTexture("_MainTex", bg360[7]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[7] = true;
                sellectButton.interactable = true;
                break;
            case 8:
                choiceMaterial.material.SetTexture("_MainTex", bg360[8]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[8] = true;
                sellectButton.interactable = true;
                break;
            case 9:
                choiceMaterial.material.SetTexture("_MainTex", bg360[9]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[9] = true;
                sellectButton.interactable = true;
                break;
            case 10:
                choiceMaterial.material.SetTexture("_MainTex", bg360[10]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[10] = true;
                sellectButton.interactable = true;
                break;
            case 11:
                choiceMaterial.material.SetTexture("_MainTex", bg360[11]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[11] = true;
                sellectButton.interactable = true;
                break;
            case 12:
                choiceMaterial.material.SetTexture("_MainTex", bg360[12]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[12] = true;
                sellectButton.interactable = true;
                break;
            case 13:
                choiceMaterial.material.SetTexture("_MainTex", bg360[13]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[13] = true;
                sellectButton.interactable = true;
                break;
            case 14:
                choiceMaterial.material.SetTexture("_MainTex", bg360[14]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[14] = true;
                sellectButton.interactable = true;
                break;
            case 15:
                choiceMaterial.material.SetTexture("_MainTex", bg360[15]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[15] = true;
                sellectButton.interactable = true;
                break;
            case 16:
                choiceMaterial.material.SetTexture("_MainTex", bg360[16]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[16] = true;
                sellectButton.interactable = true;
                break;
            case 17:
                choiceMaterial.material.SetTexture("_MainTex", bg360[17]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[17] = true;
                sellectButton.interactable = true;
                break;
            case 18:
                choiceMaterial.material.SetTexture("_MainTex", bg360[18]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[18] = true;
                sellectButton.interactable = true;
                break;
            case 19:
                choiceMaterial.material.SetTexture("_MainTex", bg360[19]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[19] = true;
                sellectButton.interactable = true;
                break;
        }
    }

    public void GoToMain()
    {
        GameManager.gameState = GameManager.GameState.MainPage;
    }

    public void ChangeVideo(int num)
    {
        switch (num)
        {
            case 0:
                ChiceButton("A");
                choiceMaterial.material.SetTexture("_MainTex", bg360[0]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[0] = true;
                sellectButton.interactable = true;
                break;
            case 1:
                ChiceButton("B");
                choiceMaterial.material.SetTexture("_MainTex", bg360[1]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[1] = true;
                sellectButton.interactable = true;
                break;
            case 2:
                ChiceButton("C");
                choiceMaterial.material.SetTexture("_MainTex", bg360[2]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[2] = true;
                sellectButton.interactable = true;
                break;
            case 3:
                ChiceButton("D");
                choiceMaterial.material.SetTexture("_MainTex", bg360[3]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[3] = true;
                sellectButton.interactable = true;
                break;
            case 4:
                ChiceButton("E");
                choiceMaterial.material.SetTexture("_MainTex", bg360[4]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[4] = true;
                sellectButton.interactable = true;
                break;
            case 5:
                ChiceButton("F");
                choiceMaterial.material.SetTexture("_MainTex", bg360[5]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[5] = true;
                sellectButton.interactable = true;
                break;
            case 6:
                ChiceButton("G");
                choiceMaterial.material.SetTexture("_MainTex", bg360[6]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[6] = true;
                sellectButton.interactable = true;
                break;
            case 7:
                ChiceButton("H");
                choiceMaterial.material.SetTexture("_MainTex", bg360[7]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[7] = true;
                sellectButton.interactable = true;
                break;
            case 8:
                ChiceButton("I");
                choiceMaterial.material.SetTexture("_MainTex", bg360[8]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[8] = true;
                sellectButton.interactable = true;
                break;
            case 9:
                ChiceButton("J");
                choiceMaterial.material.SetTexture("_MainTex", bg360[9]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[9] = true;
                sellectButton.interactable = true;
                break;
            case 10:
                ChiceButton("K");
                choiceMaterial.material.SetTexture("_MainTex", bg360[10]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[10] = true;
                sellectButton.interactable = true;
                break;
            case 11:
                ChiceButton("L");
                choiceMaterial.material.SetTexture("_MainTex", bg360[11]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[11] = true;
                sellectButton.interactable = true;
                break;
            case 12:
                ChiceButton("M");
                choiceMaterial.material.SetTexture("_MainTex", bg360[12]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[12] = true;
                sellectButton.interactable = true;
                break;
            case 13:
                ChiceButton("N");
                choiceMaterial.material.SetTexture("_MainTex", bg360[13]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[13] = true;
                sellectButton.interactable = true;
                break;
            case 14:
                ChiceButton("O");
                choiceMaterial.material.SetTexture("_MainTex", bg360[14]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[14] = true;
                sellectButton.interactable = true;
                break;
            case 15:
                ChiceButton("P");
                choiceMaterial.material.SetTexture("_MainTex", bg360[15]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[15] = true;
                sellectButton.interactable = true;
                break;
            case 16:
                ChiceButton("Q");
                choiceMaterial.material.SetTexture("_MainTex", bg360[16]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[16] = true;
                sellectButton.interactable = true;
                break;
            case 17:
                ChiceButton("R");
                choiceMaterial.material.SetTexture("_MainTex", bg360[17]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[17] = true;
                sellectButton.interactable = true;
                break;
            case 18:
                ChiceButton("S");
                choiceMaterial.material.SetTexture("_MainTex", bg360[18]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[18] = true;
                sellectButton.interactable = true;
                break;
            case 19:
                ChiceButton("T");
                choiceMaterial.material.SetTexture("_MainTex", bg360[19]);
                for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
                videoPlaySign[19] = true;
                sellectButton.interactable = true;
                break;
            case 20:
                choiceMaterial.material.SetTexture("_MainTex", beginningSkyBox);
                break;
        }
    }


    public void interactableOnOff(bool interactableState)
    {
        for (int i = 0; i < videoButton.Length; i++) { videoButton[i].interactable = false; }
        sellectButton.interactable = false;

        choiceText.font = NEXONFontStyle[0];
        resultText.font = NEXONFontStyle[0];

        choiceText.color = Color.white;
        resultText.color = Color.white;

        titleGroup.transform.localPosition = new Vector3(0.5f, -0.48f, 0);

        for (int i = 0; i < UIGroup.Length; i++)
        {
            UIGroup[i].SetActive(false);
        }

        Invoke("TitleGroupOnOff", 1);
    }

    void TitleGroupOnOff() {
        titleGroup.SetActive(false);
        GameManager.gameState = GameManager.GameState.PlayPage;
    }

    private void OnEnable()
    {
        bg360 = new Texture[20];

        for (int i = 0; i < bg360.Length; i++)
        {
            bg360[i] = Resources.Load<Texture>(Convert.ToChar(65 + i).ToString() + "_Image");
        }

        //===================================================================================//

        choiceMaterial.material.SetTexture("_MainTex", beginningSkyBox);
        videoPlaySign = new bool[videoButton.Length];
        for (int i = 0; i < videoPlaySign.Length; i++) { videoPlaySign[i] = false; }
        sellectButton.interactable = false;
        titleGroup.SetActive(true);

        //===================================================================================//

        for (int i = 0; i < videoButton.Length; i++) { videoButton[i].interactable = true; }

        choiceText.font = NEXONFontStyle[2];
        resultText.font = NEXONFontStyle[2];

        choiceText.color = Color.white;
        resultText.color = Color.white;

        resultText.text = "";

        titleGroup.transform.localPosition = new Vector3(-0.75f, 0.3f, 0);

        for (int i = 0; i < UIGroup.Length; i++)
        {
            UIGroup[i].SetActive(true);
        }
    }
}
