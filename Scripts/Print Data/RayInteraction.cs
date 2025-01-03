using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;

public class RayInteraction : MonoBehaviour
{
    public Camera playerCam;
    public float rayDistance;

    [Header ("- Depends On Bg_Colors")]
    [SerializeField]
    public SubArray_Color[] dependsOnBgColors;

    [Serializable]
    public struct SubArray_Color
    {
        [SerializeField]
        public Color[] colors;
    }

    [Header("- Depends On Bg_Texts")]
    [SerializeField]
    public SubArray_Str[] dependsOnBgTexts;

    [Serializable]
    public struct SubArray_Str
    {
        [SerializeField]
        public string[] text;
    }

    [Header ("- Depends On Bg_Image Map")]
    public Texture2D[] dependsOnBg_ImageMap = new Texture2D[20];

    [Header("- Current Data")]
    public Color[] colors;
    public string[] texts;

    public Texture2D imageMap;
    public static string objText;

    int index;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == GameManager.GameState.PlayPage && GameManager.sign == true)
        {
            Initialization();
        }

        if (TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World).GazeRay.IsValid && GameManager.gameState == GameManager.GameState.PlayPage)
        {
            if (RayInteractionHuman.humanDetect == false)
            {
                RaycastHit hit;

                Debug.DrawRay(TobiiManager.rayOrigin, TobiiManager.rayDirection * rayDistance, Color.green);

                if (Physics.Raycast(TobiiManager.rayOrigin, TobiiManager.rayDirection, out hit, rayDistance))
                {
                    if (hit.transform.tag != "GUI")
                    {
                        Renderer renderer = hit.transform.GetComponent<MeshRenderer>();
                        Texture2D texture = renderer.material.mainTexture as Texture2D;
                        Vector2 PixelUV = hit.textureCoord;
                        PixelUV.x *= texture.width;
                        PixelUV.y *= texture.height;

                        Vector2 tiling = renderer.material.mainTextureScale;
                        Color color = imageMap.GetPixel(Mathf.FloorToInt(PixelUV.x * tiling.x), Mathf.FloorToInt(PixelUV.y * tiling.y));

                        FindObjFromColor(color);

                        //Debug.Log(color);
                    }
                }
            }
        }
    }

    private void FindObjFromColor(Color color)
    {
        for (int i = 0; i < colors.Length; i++)
        {
            if (color == colors[i])
            {
                objText = texts[i];
                return;
            }
        }

        objText = "None";
        return;
    }

    private void Initialization()
    {
        playerCam = Camera.main;

        dependsOnBg_ImageMap = new Texture2D[20];

        for (int i =0; i < dependsOnBg_ImageMap.Length; i++)
        {
            dependsOnBg_ImageMap[i] = Resources.Load<Texture2D>(Convert.ToChar(65 + i).ToString() + "_Color");
        }

        if (ChoiceVideoGuiManager.videoPlaySign == null)
        {

        }
        else if (ChoiceVideoGuiManager.videoPlaySign[0] == true)
        {
            colors = new Color[dependsOnBgColors[0].colors.Length];
            texts = new string[dependsOnBgTexts[0].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[0].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[0].text[i];
            }
            imageMap = dependsOnBg_ImageMap[0];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[1] == true)
        {
            colors = new Color[dependsOnBgColors[1].colors.Length];
            texts = new string[dependsOnBgTexts[1].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[1].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[1].text[i];
            }
            imageMap = dependsOnBg_ImageMap[1];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[2] == true)
        {
            colors = new Color[dependsOnBgColors[2].colors.Length];
            texts = new string[dependsOnBgTexts[2].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[2].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[2].text[i];
            }
            imageMap = dependsOnBg_ImageMap[2];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[3] == true)
        {
            colors = new Color[dependsOnBgColors[3].colors.Length];
            texts = new string[dependsOnBgTexts[3].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[3].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[3].text[i];
            }
            imageMap = dependsOnBg_ImageMap[3];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[4] == true)
        {
            colors = new Color[dependsOnBgColors[4].colors.Length];
            texts = new string[dependsOnBgTexts[4].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[4].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[4].text[i];
            }
            imageMap = dependsOnBg_ImageMap[4];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[5] == true)
        {
            colors = new Color[dependsOnBgColors[5].colors.Length];
            texts = new string[dependsOnBgTexts[5].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[5].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[5].text[i];
            }
            imageMap = dependsOnBg_ImageMap[5];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[6] == true)
        {
            colors = new Color[dependsOnBgColors[6].colors.Length];
            texts = new string[dependsOnBgTexts[6].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[6].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[6].text[i];
            }
            imageMap = dependsOnBg_ImageMap[6];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[7] == true)
        {
            colors = new Color[dependsOnBgColors[7].colors.Length];
            texts = new string[dependsOnBgTexts[7].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[7].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[7].text[i];
            }
            imageMap = dependsOnBg_ImageMap[7];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[8] == true)
        {
            colors = new Color[dependsOnBgColors[8].colors.Length];
            texts = new string[dependsOnBgTexts[8].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[8].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[8].text[i];
            }
            imageMap = dependsOnBg_ImageMap[8];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[9] == true)
        {
            colors = new Color[dependsOnBgColors[9].colors.Length];
            texts = new string[dependsOnBgTexts[9].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[9].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[9].text[i];
            }
            imageMap = dependsOnBg_ImageMap[9];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[10] == true)
        {
            colors = new Color[dependsOnBgColors[10].colors.Length];
            texts = new string[dependsOnBgTexts[10].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[10].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[10].text[i];
            }
            imageMap = dependsOnBg_ImageMap[10];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[11] == true)
        {
            colors = new Color[dependsOnBgColors[11].colors.Length];
            texts = new string[dependsOnBgTexts[11].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[11].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[11].text[i];
            }
            imageMap = dependsOnBg_ImageMap[11];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[12] == true)
        {
            colors = new Color[dependsOnBgColors[12].colors.Length];
            texts = new string[dependsOnBgTexts[12].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[12].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[12].text[i];
            }
            imageMap = dependsOnBg_ImageMap[12];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[13] == true)
        {
            colors = new Color[dependsOnBgColors[13].colors.Length];
            texts = new string[dependsOnBgTexts[13].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[13].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[13].text[i];
            }
            imageMap = dependsOnBg_ImageMap[13];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[14] == true)
        {
            colors = new Color[dependsOnBgColors[14].colors.Length];
            texts = new string[dependsOnBgTexts[14].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[14].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[14].text[i];
            }
            imageMap = dependsOnBg_ImageMap[14];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[15] == true)
        {
            colors = new Color[dependsOnBgColors[15].colors.Length];
            texts = new string[dependsOnBgTexts[15].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[15].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[15].text[i];
            }
            imageMap = dependsOnBg_ImageMap[15];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[16] == true)
        {
            colors = new Color[dependsOnBgColors[16].colors.Length];
            texts = new string[dependsOnBgTexts[16].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[16].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[16].text[i];
            }
            imageMap = dependsOnBg_ImageMap[16];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[17] == true)
        {
            colors = new Color[dependsOnBgColors[17].colors.Length];
            texts = new string[dependsOnBgTexts[17].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[17].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[17].text[i];
            }
            imageMap = dependsOnBg_ImageMap[17];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[18] == true)
        {
            colors = new Color[dependsOnBgColors[18].colors.Length];
            texts = new string[dependsOnBgTexts[18].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[18].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[18].text[i];
            }
            imageMap = dependsOnBg_ImageMap[18];
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[19] == true)
        {
            colors = new Color[dependsOnBgColors[19].colors.Length];
            texts = new string[dependsOnBgTexts[19].text.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = dependsOnBgColors[19].colors[i];
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = dependsOnBgTexts[19].text[i];
            }
            imageMap = dependsOnBg_ImageMap[19];
        }
    }

    private void OnDisable()
    {
        TobiiXR.Stop();
    }
}