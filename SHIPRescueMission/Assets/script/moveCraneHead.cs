using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCraneHead : MonoBehaviour
{
    [SerializeField] private ObjectSelection chosenObject;

    public float sensitivityX = 1.0f;
    private Rigidbody ourBody;
    private Vector3 startPos;
    private float currentVertical;
    public float vertical = 50f;
    private float verticalVelocity;

    // Update is called once per frame
    void Update()
    {
        float lower = Input.GetAxis("Vertical");
        if (chosenObject.selected == this.gameObject && transform.localPosition.y < startPos.y + 200.0f)
        {
            moveCraneVertical(lower);
        }
    }
    private void Start()
    {
        startPos = transform.localPosition;
        ourBody = GetComponent<Rigidbody>();
    }
   
    void moveCraneVertical(float input)
    {
        verticalVelocity = Mathf.Lerp(currentVertical, vertical, 1f) * input;
        Vector3 verticalInput = transform.up * verticalVelocity * Time.deltaTime;
        ourBody.MovePosition(ourBody.position + verticalInput);
        
    }
}

