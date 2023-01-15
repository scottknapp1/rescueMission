using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    public GameObject craneTurn;
    public GameObject craneBarPivot;
    public GameObject lowerCraneRope;
    public GameObject craneClaw;
    public GameObject selected;

    [SerializeField] private GameObject contolsCraneBarText;  
    [SerializeField] private GameObject contolsCraneTurnText;  
    [SerializeField] private GameObject contolsCraneRopeText;  

    // Start is called before the first frame update
    void Start()
    {
        selected = craneTurn;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp("1"))
        {
            selected = craneTurn;
            changeUI(contolsCraneTurnText);
        }
        if (Input.GetKeyUp("2"))
        {
            selected = craneBarPivot;
            changeUI(contolsCraneBarText);
        }
        if (Input.GetKeyUp("3"))
        {
            selected = lowerCraneRope;
            changeUI(contolsCraneRopeText);
        }
        if (Input.GetKeyUp("4"))
        {
            selected = craneClaw;
        }
    }
    void changeUI(GameObject obj)
    {
        contolsCraneBarText.SetActive(false);
        contolsCraneTurnText.SetActive(false);
        contolsCraneRopeText.SetActive(false);
        obj.SetActive(true);
    }
}

