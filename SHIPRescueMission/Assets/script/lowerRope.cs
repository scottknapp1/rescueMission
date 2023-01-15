using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lowerRope : MonoBehaviour
{
    [SerializeField] private ObjectSelection chosenObject;
    [SerializeField] private GameObject link;
    [SerializeField] private GameObject hinge;
    [SerializeField] private List<GameObject> rope = new List<GameObject>();


    // Update is called once per frame
    void Update()
    {

        if (chosenObject.selected == this.gameObject)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                addSectionRope();
                
            }
            
        }
    }

    private void Awake()
    {


    }

    void addSectionRope()
    {       
        GameObject newHinge = Instantiate(hinge, rope[rope.Count - 1].transform.position, rope[rope.Count - 1].transform.rotation);
        GameObject newLink = Instantiate(link, rope[rope.Count-1].transform.position, rope[rope.Count - 1].transform.rotation);

        rope[rope.Count - 1].GetComponent<HingeJoint>().connectedBody = newLink.GetComponent<Rigidbody>();

        newLink.transform.position += new Vector3(0.4f, 0, 0);
        rope.Add(newLink);

        HingeJoint[] jointsNext = newHinge.GetComponents<HingeJoint>();
        jointsNext[0].connectedBody = GetComponent<Rigidbody>();
        jointsNext[1].connectedBody = newLink.GetComponent<Rigidbody>();

        //newHinge.transform.position += new Vector3(0.13f, 0, 0);
        rope.Add(newHinge);
    }
}
