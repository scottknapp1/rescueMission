using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlicker : MonoBehaviour
{
    private Light pointlight;

    private void Start()
    {
        pointlight = GetComponent<Light>();
    }

    private void Update()
    {
        pointlight.intensity = Mathf.PingPong(Time.time* 50, 2.5f) + 2.5f;
    }
}
