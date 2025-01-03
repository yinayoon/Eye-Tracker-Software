using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WriteToCSVFile : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
    //    Directory.CreateDirectory("D:/Result Folder/Excel Data");
    //    Directory.CreateDirectory("D:/Result Folder/Composite Image");
    //}

    public void addRecordButton()
    {
        addRecord("D:/Result Folder/Excel Data/Data_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv");
    }

    private void addRecord(string filepath)
    {
        try
        {
            using(System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                file.WriteLine("idx" + "," + "time" + "," + "ROI" + "," + "Sccade" + "," + "totalLanth" + "," + "leftBlink" + "," + "rightBlink");

                float sum = 0;
                for (int i = 1; i < DataManager.distanceFloat.Count; i++)
                {
                    sum += DataManager.distanceFloat[i];
                }

                for (int i = 0; i < 1; i++)
                {
                    file.WriteLine((i + 1) + "," + DataManager.timeNumList[i] + "," + DataManager.objNameList[i] + "," + "" + "," + sum + "," + EyeBlinking.leftBlink + "," + EyeBlinking.rightBlink);
                }

                for (int i = 1; i < DataManager.objNameList.Count; i++)
                {
                    if (i < DataManager.distanceFloat.Count)
                    {
                        file.WriteLine((i + 1) + "," + DataManager.timeNumList[i] + "," + DataManager.objNameList[i] + "," + DataManager.distanceFloat[i]);
                    }
                }
            }
        }
        catch(Exception ex)
        {
            throw new ApplicationException("This program did an oopsie :", ex);
        }
    }

    private void OnEnable()
    {
        Directory.CreateDirectory("D:/Result Folder/Excel Data");
        Directory.CreateDirectory("D:/Result Folder/Composite Image");
    }
}