using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markerOnOff : MonoBehaviour
{
    
    [SerializeField] private GameObject warning;
    [SerializeField] private GameObject dropWarning;
    [SerializeField] private GameObject ship;
    [SerializeField] private Camera pipCam;

    void Start()
    {
        warning.gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ship"))
        {
            warning.gameObject.SetActive(false);
            pipCam.gameObject.SetActive(true);
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ship"))
        {
            warning.gameObject.SetActive(true);
            pipCam.gameObject.SetActive(false);
        }
    }
}
