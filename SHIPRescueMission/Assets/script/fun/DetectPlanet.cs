using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlanet : MonoBehaviour
{
    public float hoverEnergy = 30.0f;
    public GameObject myParent;
    public GameObject myGrandParent;
    public float movementSpeed = 0.05f;
    private ObjectSelection chosenObject;

    private void Update()
    {
        if (chosenObject.selected == this.gameObject)
        {
            moveSnatcher();
        }
    }
    private void Awake()
    {
        GameObject GameCon = GameObject.FindGameObjectWithTag("GameController");
        chosenObject = GameCon.GetComponent<ObjectSelection>();

        myParent = this.transform.parent.gameObject;

        Vector3 lookPos = myParent.transform.position;
        Vector3 newLookPos = new Vector3(lookPos.x, this.transform.position.y, lookPos.z);
        this.transform.LookAt(newLookPos);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("planet"))
        {
            Debug.Log("Hit by : " + other);
            Rigidbody holder = other.GetComponent<Rigidbody>();

            Vector3 turn = new Vector3(0.3f, 0.3f, 0.3f);
            holder.AddRelativeTorque(turn);

            Animator anim = holder.transform.parent.gameObject.GetComponent<Animator>();
            Debug.Log("parent animator is : " + anim);

            anim.speed = 0;
            holder.isKinematic = false;
            holder.useGravity = true;
            holder.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            holder.AddForce(Vector3.up * hoverEnergy, ForceMode.Acceleration);

        }
    }
    void moveSnatcher()
    {
        float movement = 0.0f;

        if (Input.GetKey("up"))
        {
            movement = movementSpeed;
            Debug.Log("up");
        }
        if (Input.GetKey("down"))
        {
            movement = -movementSpeed;
            Debug.Log("down");
        }
        if (movement != 0)
        {
            Vector3 moving = new Vector3(0.0f, 0.0f, movement);
           this.transform.Translate(moving);
        }

    }
}
