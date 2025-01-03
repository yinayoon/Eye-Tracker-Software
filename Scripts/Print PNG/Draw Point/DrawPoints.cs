using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawPoints : MonoBehaviour
{
    public GameObject pointer;
    public GameObject pointerGroup;
    public Camera cam;

    public float generateTime;
    int indexText;
    int indexColor;
    int index;
    public static float timeToDrawLine;

    private Vector3 pointPos = TobiiManager.ray;
    public static Vector3 pointArrayPos;
    private List<Vector3> pointPositions = new List<Vector3>();

    public static bool colorChangeSign;
    public Color[] pointColor;
    private List<int> changeColorNum = new List<int>();

    // Update is called once per frame
    void Update()
    {
        timeToDrawLine = generateTime;
    }

    IEnumerator SavePoint()
    {
        Debug.Log("SavePoint!!");
        while (true)
        {
            if (TobiiManager.gazeRaySign == true)
            {
                pointPositions.Add(TobiiManager.ray);

                if (colorChangeSign == true)
                {
                    changeColorNum.Add(index);
                    colorChangeSign = false;
                }
                index++;

                yield return new WaitForSeconds(generateTime);
            } else yield return new WaitForSeconds(1);
        }
    }

    public void DrawPoint()
    {
        Debug.Log("DrawPoint!!");
        for (int i = 0; i < pointPositions.Count; i++)
        {
            // 프리펩을 이용한 인스텐스 생성.
            GameObject mPointer = Instantiate(pointer, pointPositions[i], Quaternion.identity);

            // 인스텐스 이름 변경.
            mPointer.name = "pointObject_" + pointer.transform.position;
            mPointer.transform.parent = pointerGroup.transform;

            // Text 속 숫자 증가.
            GameObject textObject = mPointer.transform.GetChild(1).gameObject;
            textObject.GetComponent<TextMesh>().text = indexText.ToString();

            if (indexText > 100) { indexText = 0; }
            else { indexText++; }

            // 색상 변경.
            for (int j = 0; j < changeColorNum.Count; j++)
            {
                if(i == changeColorNum[j])
                {
                    indexColor++;
                    if (indexColor >= 4)
                    {
                        indexColor = 0;
                    }
                }
            }
            mPointer.GetComponent<Renderer>().material.color = pointColor[indexColor]; 

            // 포인트 카메라 바라보기.
            Vector3 direction = cam.transform.position - mPointer.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            mPointer.transform.rotation = targetRotation;
            mPointer.transform.rotation *= Quaternion.Euler(1, 180, 1);
        }
    }

    private void DistroyObject()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PointImage");

        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i]); // objects를 파괴한다.
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();

        GameObject[] objects = GameObject.FindGameObjectsWithTag("PointImage");

        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i]); // objects를 파괴한다.
        }

        pointPositions = new List<Vector3>();
        changeColorNum = new List<int>();
    }

    private void OnEnable()
    {
        //colorChangeSign = false;
        //
        //indexText = 0;
        //indexColor = 0;
        //index = 0;

        StartCoroutine("SavePoint");

        timeToDrawLine = generateTime;
        colorChangeSign = false;

        indexText = 0;
        indexColor = 0;
        index = 0;

        pointerGroup = GameObject.Find("PointGroup");
        pointColor = new Color[5];

        pointColor[0].r = 1;
        pointColor[0].g = 0.2745098f;
        pointColor[0].b = 0.2815812f;
        pointColor[0].a = 1;

        pointColor[1].r = 0.2995515f;
        pointColor[1].g = 1;
        pointColor[1].b = 0.2745098f;
        pointColor[1].a = 1;

        pointColor[2].r = 0.2745098f;
        pointColor[2].g = 0.6046144f;
        pointColor[2].b = 1;
        pointColor[2].a = 1;

        pointColor[3].r = 1;
        pointColor[3].g = 0.2745098f;
        pointColor[3].b = 0.9228037f;
        pointColor[3].a = 1;

        pointColor[4].r = 1;
        pointColor[4].g = 0.9787252f;
        pointColor[4].b = 0.2745098f;
        pointColor[4].a = 1;
    }
}