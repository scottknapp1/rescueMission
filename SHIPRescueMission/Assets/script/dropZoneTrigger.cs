using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropZoneTrigger : MonoBehaviour
{
    [SerializeField] private CreatFixerPos fixer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ship"))
        {
            fixer.inDropZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ship"))
        {
            fixer.inDropZone = false;
        }
    }
}
