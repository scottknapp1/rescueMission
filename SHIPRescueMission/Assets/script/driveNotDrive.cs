using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driveNotDrive : MonoBehaviour
{
    public static driveNotDrive gameData; // used to share all data in this class to all others that call it 
    private void Awake() { gameData = this; }
    
    public GameObject player = null;
    public GameObject ship = null;

    [SerializeField] GameObject room;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Camera shipCam;

    [SerializeField] private GameObject dockTrigger;
    [SerializeField] private GameObject cabinTriggerCam;
    [SerializeField] private GameObject cabinText;
    
    [SerializeField] private GameObject bladeOne;
    [SerializeField] private GameObject bladeTwo;
    [SerializeField] private GameObject fan;
    [SerializeField] private GameObject engineSound;

    [SerializeField] private Animator anim;


    private bool inShip = false;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (inShip)
        {
            fan.transform.Rotate(0, 10, 0);
            bladeOne.transform.Rotate(10, 0, 0);
            bladeTwo.transform.Rotate(10, 0, 0);
            Vector3 shiprot = ship.transform.rotation.eulerAngles;
            float turn = Input.GetAxis("shipTurn");
            if(turn == 0)
            {
                ship.transform.rotation = Quaternion.Euler(shiprot.x, shiprot.y, Mathf.PingPong(Time.time, 10) - 5);
            }
        }
    }
     public void getOutOfShip()
    {
        if (!inShip)
        {
            //getting in
            player.SetActive(false);
            ship.GetComponent<ImprovedShipMovement>().enabled = true;
            ship.GetComponent<Rigidbody>().isKinematic = false;
            cabinText.SetActive(false);
            dockTrigger.SetActive(true);
            cabinTriggerCam.SetActive(false);
            inShip = true;
            playerCam.enabled = false;
            shipCam.enabled = true;
            engineSound.SetActive(true);
        }
        else
        {
            //getting out
            player.SetActive(true);
            player.transform.position = room.transform.position;
            ship.GetComponent<ImprovedShipMovement>().enabled = false;
            ship.GetComponent<Rigidbody>().isKinematic = true;
            dockTrigger.SetActive(false);
            cabinText.SetActive(true);
            cabinTriggerCam.SetActive(true);
            playerCam.enabled = true;
            shipCam.enabled = false;
            inShip = false;
            engineSound.SetActive(false);
        }
    }
}
