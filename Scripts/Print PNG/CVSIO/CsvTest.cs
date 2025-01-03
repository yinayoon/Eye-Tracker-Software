using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CsvTest : MonoBehaviour
{    
    float addition;
    float highNum;
    float maximumIndex;

    public void Start()
    {
        addition = 0;
        highNum = 0;


        Directory.CreateDirectory("D:/360CsvFolder");
    }

    public void PrintCsv()
    {
        AllData();
        SelectData();
    }

    public void AllData()
    {
        using (var writer = new CsvFileWriter("D:/360CsvFolder/ResultAll_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv"))
        {
            //Debug.Log("Print");
            List<string> columns = new List<string>() { "No.", "X", "Y", "Z", "Distance" };// making Index Row
            int j = 0;

            writer.WriteRow(columns);
            columns.Clear();

            for (int i = 0; i < DetectData.listPos.Count; i++)
            {
                columns.Add(i.ToString());
                columns.Add(DetectData.listPos[i].x.ToString()); // X
                columns.Add(DetectData.listPos[i].y.ToString()); // Y
                columns.Add(DetectData.listPos[i].z.ToString()); // Z

                if (i > 0)
                {
                    columns.Add(((DetectData.listPos[j + 1] - DetectData.listPos[j]).magnitude).ToString()); // Distance
                    j++;
                }

                writer.WriteRow(columns);
                columns.Clear();
            }
        }
    }

    public void SelectData()
    {
        using (var writer = new CsvFileWriter("D:/360CsvFolder/ResultSelect_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv"))
        {
            //Debug.Log("Print");
            List<string> columns = new List<string>() { "Maximum Distance", "Maximum Distance Pos", "All Addition Distance" };// making Index Row
            List<float> distance = new List<float>();
 
            int k = 0;

            writer.WriteRow(columns);
            columns.Clear();

            for (int i = 0; i < DetectData.listPos.Count; i++)
            {
                if (i > 0)
                {
                    distance.Add(((DetectData.listPos[k + 1] - DetectData.listPos[k]).magnitude));
                    k++;
                }
            }

            for (int j = 0; j < distance.Count; j++)
            {
                if (distance[j] > highNum)
                {
                    highNum = (float)distance[j];
                    maximumIndex = j;
                }
                
                addition += (float)distance[j];
            }

            maximumIndex += 1;

            columns.Add(highNum.ToString());
            columns.Add(maximumIndex.ToString());
            columns.Add(addition.ToString());

            writer.WriteRow(columns);
            columns.Clear();

            highNum = 0;
            maximumIndex = 0;
            addition = 0;
        }
    }
}