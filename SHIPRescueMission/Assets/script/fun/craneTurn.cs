using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craneTurn : MonoBehaviour
{
    public float sensitivityX = 1.0f;

    [SerializeField] private ObjectSelection chosenObject;

    // Update is called once per frame
    void Update()
    {
        float turn = Input.GetAxis("Turn");
        
        if (chosenObject.selected == this.gameObject)
        {
            moveCraneHorizontal(turn);            
        }
    }

    private void Awake()
    {
        
    }
    void moveCraneHorizontal(float mouseXInput)
    {
        //Rigidbody ourbody = this.GetComponent<Rigidbody>();
        //Quaternion deltaRotation = Quaternion.Euler(0f, mouseXInput * sensitivityX, 0f);
        //ourbody.MoveRotation(ourbody.rotation * deltaRotation);

        transform.Rotate(0, mouseXInput * sensitivityX * Time.deltaTime, 0);
    }
 

}


