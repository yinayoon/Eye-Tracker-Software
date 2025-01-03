using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    public LineRenderer lineRenderer;

    private Vector3 prevPos;
    private Vector3 currPos;

    private int indexLine;

    private List<Vector3> pointPositions = new List<Vector3>();

    IEnumerator GenerateLine()
    {
        while (true)
        {
            if (TobiiManager.gazeRaySign == true)
            {
                prevPos = DrawPoints.pointArrayPos;

                lineRenderer.positionCount = indexLine + 2;

                lineRenderer.SetPosition(indexLine, prevPos);
                lineRenderer.SetPosition(indexLine + 1, currPos);

                yield return new WaitForSeconds(DrawPoints.timeToDrawLine);

                indexLine++;
                currPos = prevPos;
            }
            else yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SaveLine()
    {
        while (true)
        {
            if (TobiiManager.gazeRaySign == true)
            {
                pointPositions.Add(TobiiManager.ray);
                yield return new WaitForSeconds(DrawPoints.timeToDrawLine);
            }
            else yield return new WaitForSeconds(1);
        }
    }

    public void DrawLine()
    {
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;

        for (int i = 0; i < pointPositions.Count; i++)
        {
            lineRenderer.positionCount = i + 1;
            lineRenderer.SetPosition(i, pointPositions[i]);
        }
    }

    private void OnEnable()
    {
        StopAllCoroutines();

        pointPositions = new List<Vector3>();

        indexLine = 0;

        lineRenderer.startWidth = 0f;
        lineRenderer.endWidth = 0;

        lineRenderer.positionCount = 2;
        StartCoroutine("SaveLine");
    }
}