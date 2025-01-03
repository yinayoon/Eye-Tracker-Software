using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownManager : MonoBehaviour
{
    public Dropdown dropdown;
    Dropdown.OptionData option;

    // Start is called before the first frame update
    void Awake()
    {
        dropdown = GetComponent<Dropdown>();
    
        dropdown.options.Clear();
        for (int i = 0; i < InitializeMenu.stimulationNum; i++)//1부터 10까지
        {
            option = new Dropdown.OptionData();
            option.text = Convert.ToChar(65 + i).ToString();
            dropdown.options.Add(option);
        }
    
        option = new Dropdown.OptionData();
        option.text = "None";
        dropdown.options.Add(option);
    
        dropdown.value = InitializeMenu.stimulationNum + 1;
    }
}
