using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;
    public Camera liveCamAfterTrigger;
    private bool isTriggered = false;
    
    private void Awake()
    {
        triggeredCam.enabled = false;
        isTriggered = false;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (!isTriggered)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameObject playerCharacter = GameObject.FindGameObjectWithTag("Player");
                Collider playerCollider = playerCharacter.GetComponent<Collider>();

                if (other == playerCollider)
                {
                    triggeredCam.enabled = true;
                    liveCam.enabled = false;

                    liveCam = Camera.allCameras[0];

                    triggeredCam.GetComponent<AudioListener>().enabled = true;
                    isTriggered = true;
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        triggeredCam.enabled = false;
        liveCamAfterTrigger.enabled = true;

        liveCam = Camera.allCameras[0];

        triggeredCam.GetComponent<AudioListener>().enabled = false;
        liveCamAfterTrigger.GetComponent<AudioListener>().enabled = true;
        isTriggered = false;
    }

}
