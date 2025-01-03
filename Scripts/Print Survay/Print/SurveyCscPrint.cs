using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SurveyCscPrint : MonoBehaviour
{
    public void addRecordButton()
    {
        addRecord("D:/Result Folder/Survay Data/Survay Data_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv");
    }

    private void addRecord(string filepath)
    {
        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                file.WriteLine("idx" + "," + "Result");

                for (int i = 0; i < SurveyManager.answerConclude.Length; i++)
                {
                    file.WriteLine("Q_" + (i+1) + "," + SurveyManager.answerConclude[i]);
                }
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("This program did an oopsie :", ex);
        }
    }

    private void OnEnable()
    {
        Directory.CreateDirectory("D:/Result Folder/Survay Data");
    }
}
