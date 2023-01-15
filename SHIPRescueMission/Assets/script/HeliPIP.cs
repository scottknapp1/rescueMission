using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliPIP : MonoBehaviour
{

    public enum hAlignment { left, centre, right };
    public enum vAlignment { top, middle, bottom }

    public hAlignment horAlign = hAlignment.left;
    public vAlignment vertAlign = vAlignment.top;

    public enum UnitsIn { pixles, screen_percentage }
    public UnitsIn unit = UnitsIn.screen_percentage;

    public int width = 50;
    public int height = 50;
    public int xOffset = 0;
    public int yOffset = 0;

    public bool update = true;
    private int hsize, vsize, hloc, vloc;

    // Start is called before the first frame update
    void Start()
    {
        AdjustCamera();

    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            AdjustCamera();
        }
    }

    void AdjustCamera()
    {
        int sw = Screen.width;
        int sh = Screen.height;

        float swPercent = sw * 0.01f;
        float shPercent = sh * 0.01f;

        float xOffPercent = xOffset * swPercent;
        float yOffPercent = yOffset * shPercent;

        int xOff;
        int yOff;

        if (unit == UnitsIn.screen_percentage)
        {
            hsize = width;
            vsize = height;
            xOff = (int)xOffPercent;
            yOff = (int)yOffPercent;
        }
        else
        {
            hsize = width;
            vsize = height;
            xOff = xOffset;
            yOff = yOffset;
        }

        switch (horAlign)
        {
            case hAlignment.left:
                hloc = xOff;
                break;
            case hAlignment.right:
                int justifiedRight = (sw - hsize);
                hloc = (justifiedRight - xOff);
                break;
            case hAlignment.centre:
                float justifiedCentre = (sw * 0.5f) - (hsize * 0.5f);
                hloc = (int)(justifiedCentre - xOff);
                break;
        }

        switch (vertAlign)
        {
            case vAlignment.top:
                int justifiedTop = sh - vsize;
                vloc = (justifiedTop - yOff);
                break;
            case vAlignment.bottom:
                vloc = yOff;
                break;
            case vAlignment.middle:
                float jusifiedMiddle = (sh * 0.5f) - (vsize * 0.5f);
                vloc = (int)(jusifiedMiddle - yOff);
                break;
        }
        GetComponent<Camera>().pixelRect = new Rect(hloc, vloc, hsize, vsize);
    }

}
