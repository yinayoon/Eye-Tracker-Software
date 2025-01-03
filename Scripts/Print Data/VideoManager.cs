using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    [Header("- Video Player")]
    public VideoPlayer[] originVideoPlayer;
    public VideoPlayer[] humanDetectingVideoPlayer;

    [Header("- Original Video Clip")]
    public VideoClip[] originVideoClip = new VideoClip[20];

    [Header("- Human Detecting Video Clip")]
    public VideoClip[] humanDetectingVideoClip = new VideoClip[20];

    [Header("- Event")]
    public UnityEvent printFunc;

    [Header("- Audio Player")]
    public AudioSource[] audioSource;

    [Header("- Audio Clips")]
    [SerializeField]
    public SubArray[] audioClip_ = new SubArray[20];

    [Serializable]
    public struct SubArray
    {
        [SerializeField]
        public AudioClip[] clip;
    }

    public static string videoName;
    public static bool signOfEyetracking;

    [Header("- RayCast OBJ / HUMAN")]
    public RayInteraction rayInteraction;
    public RayInteractionHuman rayInteractionHuman;

    [Header("- Survey Manager")]
    public GameObject surveyManagerObj;
    public SurveyManager surveyManager;

    [Header("- Eye Tracker")]
    public GameObject eyeTracker;

    // Start is called before the first frame update
   //void Start()
   //{
   //    signOfEyetracking = true;
   //
   //    rayInteraction.enabled = true;
   //    rayInteractionHuman.enabled = true;
   //
   //    for (int i = 0; i < originVideoClip.Length; i++)
   //    {
   //        originVideoPlayer[i].clip = originVideoClip[i];
   //        humanDetectingVideoPlayer[i].clip = humanDetectingVideoClip[i];
   //    }
   //
   //    for (int i = 0; i < audioSource.Length; i++)
   //    {
   //        audioSource[i].clip = audio[0].clip[i];
   //    }
   //
   //    StartCoroutine("CoVideoPlayer");
   //    StartCoroutine("CoAudioPlayer");
   //
   //    surveyManagerObj.SetActive(false);
   //    eyeTracker.SetActive(true);
   //}

    private void Update()
    {

    }

    IEnumerator CoVideoPlayer()
    {
        videoName = originVideoClip[0].name;

        //for (int i = 0; i < originVideoClip.Length; i++)
        //{
        //    originVideoPlayer[0].Play();
        //    humanDetectingVideoPlayer[0].Play();
        //}

        yield return new WaitForSeconds(10f);// ((ulong)(originVideoPlayer[0].frameCount / originVideoClip[0].frameRate));

        for (int i = 0; i < originVideoClip.Length; i++)
        {
            originVideoPlayer[0].Stop();
            humanDetectingVideoPlayer[0].Stop();
        }

        //printFunc.Invoke();
        //rayInteraction.enabled = false;
        //rayInteractionHuman.enabled = false;
        GameManager.gameState = GameManager.GameState.None;

        signOfEyetracking = false;

        eyeTracker.SetActive(false);
        surveyManagerObj.SetActive(true);

        for (int i = 0; i < originVideoClip.Length; i++)
        {
            originVideoPlayer[0].Play();
        }
    }

    IEnumerator CoAudioPlayer()
    {
        yield return new WaitForSeconds(10f);//((ulong)(originVideoPlayer[0].frameCount / originVideoClip[0].frameRate));

        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].Stop();
        }

        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].Play();
        }
    }

    private void OnEnable()
    {
        StopAllCoroutines();

        signOfEyetracking = true;

        //rayInteraction.enabled = true;
        //rayInteractionHuman.enabled = true;

        originVideoClip = new VideoClip[20];
        humanDetectingVideoClip = new VideoClip[20];
        audioClip_ = new SubArray[20];
        for (int i = 0; i < audioClip_.Length; i++) { audioClip_[i].clip = new AudioClip[4]; }

        for (int i = 0; i < originVideoClip.Length; i++) { originVideoClip[i] = Resources.Load<VideoClip>(Convert.ToChar(65 + i).ToString()); }
        for (int i = 0; i < humanDetectingVideoClip.Length; i++) { humanDetectingVideoClip[i] = Resources.Load<VideoClip>(Convert.ToChar(65 + i).ToString() + "_detected"); }
        for (int i = 0; i < audioClip_.Length; i++)
        {
            for(int j = 0; j < audioClip_[i].clip.Length; j++)
            {
                audioClip_[i].clip[j] = Resources.Load<AudioClip>(Convert.ToChar(65 + i).ToString() + "_Audio_" + j);
            }
        }

        if(ChoiceVideoGuiManager.videoPlaySign == null)
        {

        }
        else if (ChoiceVideoGuiManager.videoPlaySign[0] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[0];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[0];
            Debug.Log(humanDetectingVideoPlayer[0].clip.name);
            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[0].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if (ChoiceVideoGuiManager.videoPlaySign[1] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[1];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[1];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[1].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[2] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[2];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[2];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[2].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[3] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[3];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[3];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[3].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[4] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[4];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[4];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[4].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[5] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[5];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[5];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[5].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[6] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[6];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[6];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[6].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[7] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[7];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[7];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[7].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[8] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[8];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[8];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[8].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[9] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[9];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[9];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[9].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[10] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[10];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[10];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[10].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[11] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[11];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[11];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[11].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[12] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[12];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[12];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[12].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[13] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[13];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[13];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[13].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[14] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[14];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[14];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[14].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[15] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[15];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[15];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[15].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[16] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[16];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[16];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[16].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[17] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[17];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[17];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[17].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[18] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[18];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[18];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[18].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }
        else if(ChoiceVideoGuiManager.videoPlaySign[19] == true)
        {
            originVideoPlayer[0].clip = originVideoClip[19];
            humanDetectingVideoPlayer[0].clip = humanDetectingVideoClip[19];

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].clip = audioClip_[19].clip[i];
                audioSource[i].clip = audioClip_[19].clip[i];
                audioSource[i].clip = audioClip_[19].clip[i];
            }

            for (int i = 0; i < originVideoClip.Length; i++)
            {
                originVideoPlayer[0].Play();
                humanDetectingVideoPlayer[0].Play();
            }

            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].Play();
            }
        }

        StartCoroutine("CoVideoPlayer");
        StartCoroutine("CoAudioPlayer");

        surveyManagerObj.SetActive(false);
        eyeTracker.SetActive(true);
    }
}
