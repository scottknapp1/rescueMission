using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driveCrane : MonoBehaviour
{
    public GameObject player = null;
    public KeyCode enterExitKey = KeyCode.G;
    public GameObject crane = null;
    public GameObject craneTrigger = null;
 
    private bool inCrane = false;
    [SerializeField]private openClaw clawOpen;
    [SerializeField] private Camera craneCamera;
    [SerializeField] private GameObject craneHead;
    [SerializeField] private GameObject textCraneEnterExit;
    [SerializeField] private GameObject craneTurnText;
    [SerializeField] private GameObject craneBarText;
    [SerializeField] private GameObject craneRopeText;
    [SerializeField] private GameObject allCraneText;
    [SerializeField] private GameObject craneHeasIsKinamatic;
    [SerializeField] private Camera pipCam;
    [SerializeField] private GameObject missionText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(enterExitKey) &&
            Vector3.Distance(craneTrigger.transform.position, player.transform.position) < 2)
        {
            getOutOfCrane();
        }
    }
    void getOutOfCrane()
    {
        if (!inCrane)
        {
            //getting in
            player.SetActive(false);
            crane.GetComponent<craneTurn>().enabled = true;
            clawOpen.enabled = true;
            crane.GetComponentInChildren<craneLower>().enabled = true;
            crane.GetComponentInChildren<moveCraneHead>().enabled = true;
            inCrane = true;
            craneCamera.enabled = true;
            allCraneText.SetActive(true);
            textCraneEnterExit.SetActive(false);
            craneTurnText.SetActive(true);
            pipCam.gameObject.SetActive(true);
            missionText.SetActive(false);
            craneHeasIsKinamatic.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            //getting out
            crane.GetComponent<craneTurn>().enabled = false;
            clawOpen.enabled = false;
            crane.GetComponentInChildren<craneLower>().enabled = false;
            crane.GetComponentInChildren<moveCraneHead>().enabled = false;
            player.SetActive(true);
            craneCamera.enabled = false;
            inCrane = false;
            textCraneEnterExit.SetActive(true);
            craneTurnText.SetActive(false);
            craneBarText.SetActive(false);
            craneRopeText.SetActive(false);
            allCraneText.SetActive(false);
            pipCam.gameObject.SetActive(false);
            missionText.SetActive(true);
            craneHeasIsKinamatic.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
