using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRenderController : MonoBehaviour
{
    private LineRenderer lineRef;
    private Transform[] points;

    private void Awake()
    {
        lineRef = GetComponent<LineRenderer>();
    }
   
    public void setupLine(Transform[] points)
    {
        lineRef.positionCount = points.Length;
        this.points = points;
    }
    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lineRef.SetPosition(i, points[i].position);
        }
    }
}
