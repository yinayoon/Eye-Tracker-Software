using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CaptureManager : MonoBehaviour
{
    string path;

    public static byte[] image;    
    public static byte[] originImage;
    public static byte[] pointImage;

    string[] baseMask = new string[] { "Everything", "Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Interactable", "Not Human" };
    
    GameObject rawImageObj;
    RawImage rawImage;

    Texture2D firTex;
    byte[] firFileData;
    string firFilePath;

    Texture2D secTex;
    byte[] secFileData;
    string secFilePath;

    public void VR360ImageCapture()
    {
        Camera.main.transform.rotation = Quaternion.identity;

        image = I360Render.Capture(2880, true, Camera.main, true);
        string name = path + "Origin Image" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";
        File.WriteAllBytes(name, image);
    }

    public void PointCapture()
    {
        Camera.main.transform.rotation = Quaternion.identity;

        Camera.main.cullingMask = LayerMask.GetMask("Interactable");
        Camera.main.clearFlags = CameraClearFlags.SolidColor;

        image = I360Render.Capture(2880, true, Camera.main, true);
        string name = path + "Point Image" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";
        File.WriteAllBytes(name, image);

        Camera.main.cullingMask = LayerMask.GetMask(baseMask);
        Camera.main.clearFlags = CameraClearFlags.Skybox;
    }

    public void CompositeImage()
    {
        Camera.main.transform.rotation = Quaternion.identity;

        // 오리지널 이미지
        Camera.main.cullingMask = LayerMask.GetMask("Not Human");
        originImage = I360Render.Capture(2880, true, Camera.main, true);

        // 포인트 이미지
        Camera.main.cullingMask = LayerMask.GetMask("Interactable");
        Camera.main.clearFlags = CameraClearFlags.SolidColor;

        pointImage = I360Render.Capture(2880, true, Camera.main, true);
        string name = path + "Point Image" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

        Camera.main.cullingMask = LayerMask.GetMask(baseMask);
        Camera.main.clearFlags = CameraClearFlags.Skybox;

        // 이미지 파일을 읽어옴.
        firTex = new Texture2D(2, 2);
        firTex.LoadImage(originImage);

        // 원본 byte 배열을 생성하고 픽셀 값을 채움.
        Color32[] colors = firTex.GetPixels32();
        byte[] srcdata = new byte[firTex.width * firTex.height * 3];
        for (int i = 0, idx = 0; i < firTex.width * firTex.height; i++, idx += 3)
        {
            srcdata[idx + 0] = colors[i].b;
            srcdata[idx + 1] = colors[i].g;
            srcdata[idx + 2] = colors[i].r;
        }

        // 영상처리 수행_컬러를 흑백으로 변경.
        byte[] dstdata = new byte[firTex.width * firTex.height * 3];
        for (int i = 0, idx = 0; i < firTex.width * firTex.height; i++, idx += 3)
        {
            int b = (int)srcdata[idx + 0];
            int g = (int)srcdata[idx + 1];
            int r = (int)srcdata[idx + 2];

            byte gray = (byte)((r + g + b) / 3);

            dstdata[idx + 0] = gray;
            dstdata[idx + 1] = gray;
            dstdata[idx + 2] = gray;
        }

        // byte 배열을 다시 텍스처로 변경.
        Texture2D grayOuttex = new Texture2D(firTex.width, firTex.height);
        Color32[] color2 = firTex.GetPixels32();
        for (int i = 0, idx = 0; i < firTex.width * firTex.height; i++, idx += 3)
        {
            color2[i].b = dstdata[idx + 0];
            color2[i].g = dstdata[idx + 1];
            color2[i].r = dstdata[idx + 2];
            colors[i].a = 255;
        }
        grayOuttex.SetPixels32(color2);
        grayOuttex.Apply(true);

        // 합성할 이미지 파일을 읽어옴.
        secTex = new Texture2D(2, 2);
        secTex.LoadImage(pointImage);

        // 두개의 이미지를 읽어옴. (회색이 된 이미지, 합성할 이미지)
        Color32[] firColor = grayOuttex.GetPixels32();
        Color32[] secColor = secTex.GetPixels32();

        byte[] firSrcdate = new byte[firTex.width * firTex.height * 3];
        for (int i = 0, idx = 0; i < firTex.width * firTex.height; i++, idx += 3)
        {
            firSrcdate[idx + 0] = firColor[i].b;
            firSrcdate[idx + 1] = firColor[i].g;
            firSrcdate[idx + 2] = firColor[i].r;
        }

        byte[] secSrcdate = new byte[secTex.width * secTex.height * 3];
        for (int i = 0, idx = 0; i < secTex.width * secTex.height; i++, idx += 3)
        {
            secSrcdate[idx + 0] = secColor[i].b;
            secSrcdate[idx + 1] = secColor[i].g;
            secSrcdate[idx + 2] = secColor[i].r;
        }

        // 이미지 합성 진행
        byte[] compData = new byte[firTex.width * firTex.height * 3];
        for (int i = 0, idx = 0; i < firTex.width * firTex.height; i++, idx += 3)
        {
            if (secSrcdate[idx + 0] == 255 && secSrcdate[idx + 1] == 255 && secSrcdate[idx + 2] == 255)
            {
                int b = firSrcdate[idx + 0];
                int g = firSrcdate[idx + 1];
                int r = firSrcdate[idx + 2];

                compData[idx + 0] = (byte)(b);
                compData[idx + 1] = (byte)(g);
                compData[idx + 2] = (byte)(r);
            }
            else if (secSrcdate[idx + 0] != 255 && secSrcdate[idx + 1] != 255 && secSrcdate[idx + 2] != 255)
            {
                int b = secSrcdate[idx + 0];
                int g = secSrcdate[idx + 1];
                int r = secSrcdate[idx + 2];

                compData[idx + 0] = (byte)(b);
                compData[idx + 1] = (byte)(g);
                compData[idx + 2] = (byte)(r);
            }
        }

        Texture2D outtex = new Texture2D(firTex.width, firTex.height);
        Color32[] colorsCompose = firTex.GetPixels32();

        for (int i = 0, idx = 0; i < firTex.width * firTex.height; i++, idx += 3)
        {
            colorsCompose[i].b = compData[idx + 0];
            colorsCompose[i].g = compData[idx + 1];
            colorsCompose[i].r = compData[idx + 2];
            colorsCompose[i].a = 255;
        }

        outtex.SetPixels32(colorsCompose);
        outtex.Apply(true);

        string imageName; // string형 neme 변수 선언.
        imageName = path + "Composite Image_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

        // 파일 출력.
        File.WriteAllBytes(imageName, outtex.EncodeToPNG());
    }

    private void OnEnable()
    {
        path = "D:/Result Folder/Composite Image/";
    }
}
