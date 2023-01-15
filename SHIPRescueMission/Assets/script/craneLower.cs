using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class craneLower : MonoBehaviour
{
    [SerializeField] private ObjectSelection chosenObject;
    [SerializeField] private GameObject craneHead;
    public float sensitivityX = 1.0f;


    // Update is called once per frame
    void Update()
    {

        float lowerCrane = Input.GetAxis("Vertical");


        if (chosenObject.selected == this.gameObject)
        {
            pivateCraneUpDown(lowerCrane);
            moveCraneHead(lowerCrane);
        }
    }

    private void Awake()
    {


    }

    void pivateCraneUpDown(float mouseYInput)
    {
        //Rigidbody ourbody = this.GetComponent<Rigidbody>();
        //Quaternion deltaRotation = Quaternion.Euler(0f, 0f, mouseYInput * sensitivityX);
        //ourbody.MoveRotation(ourbody.rotation * deltaRotation);

        transform.Rotate(0f, 0f, mouseYInput * sensitivityX * Time.deltaTime);
    }
    void moveCraneHead(float mouseYInput)
    {
        craneHead.transform.Rotate(0f, 0f, -mouseYInput * sensitivityX * Time.deltaTime);
    }
}