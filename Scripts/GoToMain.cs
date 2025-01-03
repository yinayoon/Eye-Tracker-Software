using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMain : MonoBehaviour
{
    // 콘텐츠로 이동
    public void GoToExperiment()
    {
        SceneManager.LoadScene("Software Scene");
    }
}
