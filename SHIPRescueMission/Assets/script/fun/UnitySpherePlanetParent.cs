using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySpherePlanetParent : MonoBehaviour
{
    public bool turning = true;
    public float turnSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (turning == true)
        {
            this.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        }

    }
}
