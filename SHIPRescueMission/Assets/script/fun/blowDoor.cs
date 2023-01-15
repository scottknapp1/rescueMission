using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blowDoor : MonoBehaviour
{
    private Rigidbody hitMe;
    public float force = 30.0f;
    public float torqueforce = 30.0f;
    public Vector3 forceDirection = new Vector3(0f, -1f, 0f);


    // Start is called before the first frame update
    void Start()
    {
        hitMe = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        hitMe.AddForce(forceDirection * force, ForceMode.Force);
        hitMe.AddTorque(this.transform.right * torqueforce);
    }
}
