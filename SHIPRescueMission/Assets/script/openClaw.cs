using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openClaw : MonoBehaviour
{
    private bool isopen = false;    
    // Update is called once per frame
    void Update()
    {   
        
        if (Input.GetButtonDown("openClaw"))
        {
            isopen = !isopen;
            GetComponent<Animator>().SetBool("Open", isopen);
        }
    }
}
