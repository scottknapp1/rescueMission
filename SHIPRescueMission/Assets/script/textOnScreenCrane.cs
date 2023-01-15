using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textOnScreenCrane : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject text;
   
    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
        }
    }
}
