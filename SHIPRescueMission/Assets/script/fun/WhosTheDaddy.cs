using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhosTheDaddy : MonoBehaviour
{
    [SerializeField] private GameObject box;
    private bool hasBoxPickUp = false;
    private float timer = 0; 

  
    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Alpha4)&& hasBoxPickUp)
        {
            box.transform.parent = null;
            box.GetComponent<Rigidbody>().isKinematic = false;
            hasBoxPickUp = false;
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == box && timer > 0.5f)
        {
            box.transform.parent = this.transform;
            box.GetComponent<Rigidbody>().isKinematic = true;
            hasBoxPickUp = true;
        }
    }
}
