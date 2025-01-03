using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class GameManagerIP : MonoBehaviour
{
    public DetectData detectData;

    public void DetectDataOnOff()
    {
        detectData.enabled = false;
        detectData.enabled = true;
    }

    private void OnEnable()
    {
        detectData.enabled = true;
    }
}