using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class IPManager : MonoBehaviour
{
    GameObject rawImageObj;
    RawImage rawImage;

    string path;

    Texture2D firTex;
    byte[] firFileData;
    string firFilePath;

    Texture2D secTex;
    byte[] secFileData;
    string secFilePath;

    public void GetImage()
    {
        if (System.IO.File.Exists(firFilePath))
        {
            // 이미지 파일을 읽어옴.
            firFileData = System.IO.File.ReadAllBytes(firFilePath);
            firTex = new Texture2D(2, 2);
            firTex.LoadImage(firFileData);

            // 화면 출력.
            rawImage.texture = firTex;
        }
    }

    public void GetGrayImage()
    {
        if (System.IO.File.Exists(firFilePath))
        {
            // 이미지 파일을 읽어옴.
            firFileData = System.IO.File.ReadAllBytes(firFilePath);
            firTex = new Texture2D(2, 2);
            firTex.LoadImage(firFileData);

            // 원본 byte 배열을 생성하고 픽셀 값을 채움.
            Color32[] colors = firTex.GetPixels32();
            byte[] srcdata = new byte[firTex.width * firTex.height * 3];
            for(int i = 0, idx = 0; i < firTex.width * firTex.height; i++, idx += 3)
            {
                srcdata[idx + 0] = colors[i].b;
                srcdata[idx + 1] = colors[i].g;
                srcdata[idx + 2] = colors[i].r;
            }

            // 영상처리 수행_컬러를 흑백으로 변경.
            byte[] dstdata = new byte[firTex.width * firTex.height * 3];
            for(int i = 0, idx = 0; i < firTex.width * firTex.height; i++, idx += 3)
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
            Texture2D outtex = new Texture2D(firTex.width, firTex.height);
            Color32[] color2 = firTex.GetPixels32();
            for(int i = 0, idx = 0; i < firTex.width * firTex.height; i++, idx += 3)
            {
                color2[i].b = dstdata[idx + 0];
                color2[i].g = dstdata[idx + 1];
                color2[i].r = dstdata[idx + 2];
                colors[i].a = 255;
            }
            outtex.SetPixels32(color2);
            outtex.Apply(true);

            // 화면 출력.
            rawImage.texture = outtex;
        }
    }

    public void CompositeImage()
    {
        if (System.IO.File.Exists(firFilePath))
        {
            // 이미지 파일을 읽어옴.
            firFileData = System.IO.File.ReadAllBytes(firFilePath);
            firTex = new Texture2D(2, 2);
            firTex.LoadImage(firFileData);

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
            secFileData = System.IO.File.ReadAllBytes(secFilePath);
            secTex = new Texture2D(2, 2);
            secTex.LoadImage(secFileData);

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

            string name; // string형 neme 변수 선언.
            name = path + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

            // 화면 출력.
            rawImage.texture = outtex;

            // 파일 출력.
            File.WriteAllBytes(name, outtex.EncodeToPNG());
        }
    }

    public void CompositeImageForApp()
    {
        // 이미지 파일을 읽어옴.
        firFileData = System.IO.File.ReadAllBytes(firFilePath);
        firTex = new Texture2D(2, 2);
        firTex.LoadImage(firFileData);

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
        secFileData = System.IO.File.ReadAllBytes(secFilePath);
        secTex = new Texture2D(2, 2);
        secTex.LoadImage(secFileData);

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

        string name; // string형 neme 변수 선언.
        name = path + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

        // 화면 출력.
        rawImage.texture = outtex;

        // 파일 출력.
        File.WriteAllBytes(name, outtex.EncodeToPNG());
    }

    private void OnEnable()
    {
        Directory.CreateDirectory("D:/Composite Image");
        path = "D:/Composite Image/";

        rawImageObj = GameObject.Find("RawImage");
        rawImage = rawImageObj.GetComponent<RawImage>();

        firTex = null;
        firFileData = null;
        firFilePath = "Assets/Project/Resources/Image Processing/Test Image/Comp1.jpg";

        secTex = null;
        secFileData = null;
        secFilePath = "Assets/Project/Resources/Image Processing/Test Image/Comp2.jpg";
    }
}