using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTriggerCam : MonoBehaviour
{
    public Camera shiptriggeredCam;
    public Camera shipliveCam;
    public Camera shipliveCamAfterTrigger;
    private bool isTriggered = false;

    private void Awake()
    {
        isTriggered = false;
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (!isTriggered)
        {
            if (other.gameObject.CompareTag("ship"))
            {
                shiptriggeredCam.enabled = true;
                shipliveCam.enabled = false;

                //shipliveCam = Camera.allCameras[0];

                shiptriggeredCam.GetComponent<AudioListener>().enabled = true;
                isTriggered = true;
            }
           
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ship"))
        {
            shiptriggeredCam.enabled = false;
            shipliveCamAfterTrigger.enabled = true;

            //shipliveCam = Camera.allCameras[0];

            shiptriggeredCam.GetComponent<AudioListener>().enabled = false;
            shipliveCamAfterTrigger.GetComponent<AudioListener>().enabled = true;
            isTriggered = false;
        }
    
    }
}

