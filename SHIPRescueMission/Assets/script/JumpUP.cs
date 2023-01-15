using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUP : MonoBehaviour
{
    public float jumpVelicity = 5f;
    public float fallMuliplier = 3f;
    public float jumpMuliplier = 2f;
    public bool isLanded = true;
    private bool isJumping = false;
    private HashIDs hash;
    Rigidbody player;

    // Start is called before the first frame update
    private void Awake()
    {
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*print(isLanded);
        print(isJumping);*/

        if (Input.GetButtonDown("Jump")&& isLanded)
        {
            GetComponent<Rigidbody>().velocity += Vector3.up * jumpVelicity;
            isLanded = false;
            isJumping = true;
            GetComponent<Animator>().SetBool(hash.jump, isJumping);
        }

        if(GetComponent<Rigidbody>().velocity.y <= 0)
        {
            isLanded = true;
            isJumping = false;
            GetComponent<Animator>().SetBool(hash.jump, isJumping = false);
        }
        
        //if falling 
        if (player.velocity.y < 0)
        {
            // quicker fall 
            player.velocity += Vector3.up * Physics.gravity.y * (fallMuliplier - 1) * Time.deltaTime;
        }
        // if jumping and not holing jump (mini jump)
        else if (player.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            // quicker fall 
            player.velocity += Vector3.up * Physics.gravity.y * (jumpMuliplier - 1) * Time.deltaTime;
        }
    }
}
