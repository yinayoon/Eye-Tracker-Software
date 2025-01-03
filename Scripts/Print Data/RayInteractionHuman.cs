using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Tobii.XR;

public class RayInteractionHuman : MonoBehaviour
{
    private Camera playerCam;
    public GameObject rig;
    public float distance = 100f;
    public LayerMask whatIsTarget;

    Color color;
    Texture2D texture;
    RaycastHit hit;
    Renderer renderer_ = new Renderer();
    RenderTexture renderTexture;

    public static bool humanDetect;
    public static string humanText;

    // Start is called before the first frame update
    //void Start()
    //{
    //    playerCam = Camera.main;
    //    humanDetect = false;
    //}

    // Update is called once per frame
    void Update()
    {
        if (TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World).GazeRay.IsValid && GameManager.gameState == GameManager.GameState.PlayPage)
        {
            rig.transform.rotation = Quaternion.LookRotation(TobiiManager.rayDirection);

            //Debug.DrawRay(TobiiManager.rayOrigin + new Vector3(30,0,0), TobiiManager.rayDirection * distance + new Vector3(30, 0, 0), Color.green);
            Debug.DrawRay(rig.transform.position, rig.transform.forward * distance, Color.red);

            //if (Physics.Raycast(TobiiManager.rayOrigin + new Vector3(30, 0, 0), TobiiManager.rayDirection + new Vector3(30, 0, 0), out hit, distance, whatIsTarget))
            if (Physics.Raycast(rig.transform.position, rig.transform.forward, out hit, distance, whatIsTarget))
            {
                renderer_ = hit.transform.GetComponent<MeshRenderer>();
                //Texture2D texture = renderer.material.mainTexture as Texture2D;
                renderTexture = hit.transform.GetComponent<VideoPlayer>().texture as RenderTexture;

                if (renderTexture != null)
                {
                    StartCoroutine("ExtractPixel");
                }
            }

            //Debug.Log(color);

            if (color.r >= 0.18 && color.r < 0.5f && color.g >= 0.05f && color.g < 0.1f && color.b >= 0.95f)
            {
                humanText = "Human";
                humanDetect = true;
            }
            else if (color.r >= 0 && color.r < 0.1f && color.g >= 0.8588f && color.g < 0.9f && color.b >= 0.294117f && color.b < 0.35f)
            {
                humanText = "Bus";
                humanDetect = true;
            }
            else if (color.r >= 0 && color.r < 0.1f && color.g >= 0.76f && color.g < 0.8f && color.b >= 0.95f && color.b <= 1f)
            {
                humanText = "Car";
                humanDetect = true;
            }
            else
            {
                humanText = "None";
                humanDetect = false;
            }
        }
    }

    IEnumerator ExtractPixel()
    {
        Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);

        RenderTexture.active = renderTexture;
        tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        tex.Apply();

        texture = tex;
        Vector2 pixelUV = hit.textureCoord;

        pixelUV.x *= texture.width;
        pixelUV.y *= texture.height;

        Vector2 tiling = renderer_.material.mainTextureScale;
        color = texture.GetPixel(Mathf.FloorToInt(pixelUV.x * tiling.x), Mathf.FloorToInt(pixelUV.y * tiling.y));

        yield return new WaitForEndOfFrame();
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        playerCam = Camera.main;
        humanDetect = false;
        renderer_ = new Renderer();
    }

    private void OnDisable()
    {
        TobiiXR.Stop();
    }
}
