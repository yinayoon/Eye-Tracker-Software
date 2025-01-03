using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPLManager : MonoBehaviour
{
    public GameObject trackingManager;

    GameObject[] objects;


    IEnumerator GameObjectOnOff()
    {
        trackingManager.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        trackingManager.SetActive(true);
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        trackingManager.SetActive(true);
    }
}
