using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectData : MonoBehaviour
{
    public static List<Vector3> listPos = new List<Vector3>();

    IEnumerator SavePos()
    {
        while (true)
        {
            if (TobiiManager.gazeRaySign == true)
            {
                listPos.Add(TobiiManager.ray);
                yield return new WaitForSeconds(DrawPoints.timeToDrawLine);
            }
            else yield return new WaitForSeconds(1);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        listPos = new List<Vector3>();
    }

    private void OnEnable()
    {
        StartCoroutine("SavePos");
    }
}
