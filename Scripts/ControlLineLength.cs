using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLineLength : MonoBehaviour
{
    Transform line1;
    Transform line2;
    [Range (1, 5)]
    public float line1_Length;

    [Range (1, 5)]
    public float line2_Length;

    [Range(0, 1)]
    public float line1_Thickness;

    [Range(0, 1)]
    public float line2_Thickness;

    // Start is called before the first frame update
    void Start()
    {
        line1 = transform.GetChild(0).transform;
        line2 = transform.GetChild(1).transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lineTmp1 = new Vector3(line1_Thickness, line1_Length, 0);
        Vector3 lineTmp2 = new Vector3(line2_Length, line2_Thickness, 0);

        line1.localScale = lineTmp1;
        line2.localScale = lineTmp2;
    }
}
