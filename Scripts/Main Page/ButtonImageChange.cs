using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImageChange : MonoBehaviour
{
    public Sprite[] bgButtonImage = new Sprite[20];

    private void OnEnable()
    {
        bgButtonImage = new Sprite[20];

        for (int i = 0; i < bgButtonImage.Length; i++)
        {
            bgButtonImage[i] = Resources.Load<Sprite>(Convert.ToChar(65 + i).ToString() + "_UI");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
