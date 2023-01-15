using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameTextTrigger : MonoBehaviour
{
   
    [SerializeField] private GameObject endGameText;
    [SerializeField] private GameObject oldmission;

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            endGameText.gameObject.SetActive(true);
            oldmission.gameObject.SetActive(false);
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ship"))
        {
            endGameText.gameObject.SetActive(false);
            oldmission.gameObject.SetActive(true);
          
        }
    }
}
