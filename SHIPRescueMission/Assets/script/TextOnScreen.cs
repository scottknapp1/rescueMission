using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnScreen : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject text;
    [SerializeField] private driveNotDrive drive;

    public KeyCode enterExitKey = KeyCode.P;

    bool inPos = false;
 
    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(enterExitKey)&& inPos)
        {
            drive.getOutOfShip();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            inPos = true;
            text.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inPos = false;
            text.gameObject.SetActive(false);
        }
    }
}
