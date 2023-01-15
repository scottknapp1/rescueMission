using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCameras : MonoBehaviour
{
    public Camera FollowCam;
    public Camera StaticCam;
    public Camera pipCam;

    // Start is called before the first frame update
    void Start()
    {
        pipCam.enabled = false;

        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");

        FollowCam.enabled = true;
        StaticCam.enabled = false;

        PlayerCharacter.GetComponent<AudioListener>().enabled = true;
        StaticCam.GetComponent<AudioListener>().enabled = false;

    }
    void Update()
    {
        /* if (Input.GetKeyUp("p"))
         {
             pipCam.enabled = !pipCam.enabled;
         }*/

        pipCam.enabled = true;
    }
}
