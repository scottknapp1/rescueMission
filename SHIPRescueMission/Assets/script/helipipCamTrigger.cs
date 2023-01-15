using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helipipCamTrigger : MonoBehaviour
{
    
    [SerializeField] private GameObject crate;
    [SerializeField] private GameObject marker;
    [SerializeField] private Camera heliPipCam;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            marker.gameObject.SetActive(false);
            heliPipCam.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            marker.gameObject.SetActive(true);
            heliPipCam.gameObject.SetActive(false);
        }
    }
}
