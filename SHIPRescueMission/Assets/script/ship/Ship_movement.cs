using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_movement : MonoBehaviour
{
    //speeds
    public float forward = 20f;
    public float hover = 5f;
    public float strafe = 10f;
    public float rotateSpeed = 50f;

    //input
    private float pressForward;
    private float pressHover;
    private float pressStrafe;

    // how fast get to top speed
    private float lerpforward = 1f;
    private float lerpHover = 1f;
    private float lerpStrafe = 1f;

    private float speed;
    private float duration = 2.0f;
    private float startTime;

    private HashIDs hash;
    private Animator anim;

    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;

    private Rigidbody ourBody;

    // Start is called before the first frame update
    private void Start()
    {
        ourBody = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        anim.SetLayerWeight(1, 1f);
    }
    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            startTime = Time.time;
        }
        float t = (Time.time - startTime) / duration;

        MovementManager(v, h,t);

        // turns ship left/right 
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);

        }

        float turn = Input.GetAxis("shipTurn");
        //Rotating(turn);
    }

    // Update is called once per frame
    void Update()
    {
        // gets input
        pressForward = Mathf.Lerp(pressForward, Input.GetAxisRaw("Forward") * forward, lerpforward * Time.deltaTime);
        pressStrafe = Mathf.Lerp(pressStrafe, Input.GetAxisRaw("Strafe") * strafe, lerpStrafe * Time.deltaTime);
        pressHover = Mathf.Lerp(pressHover, Input.GetAxisRaw("Hover") * hover, lerpHover * Time.deltaTime);

        //applys input
        transform.position += transform.forward * pressForward * Time.deltaTime;
        transform.position += transform.right * pressStrafe * Time.deltaTime;
        transform.position += transform.up * pressHover * Time.deltaTime;
    }
    void Rotating(float Input_turn)
    {
       
        if (Input_turn != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, Input_turn * sensitivityX, 0f);
            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
        }
       
    }
    void MovementManager(float vertical,float horizontal,float time)
    {
        if (vertical > 0)
        {
            /*speed = Mathf.SmoothStep(0, 10, time);
            ourBody.velocity = new Vector3(0, 0, 1);
            ourBody.MovePosition(ourBody.position + transform.forward * vertical * speed * Time.fixedDeltaTime);*/

            anim.SetFloat(hash.speedFloat, 1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", false);
        }
        if (vertical < 0)
        {
            /*speed = Mathf.SmoothStep(0, 10, time);
            ourBody.velocity = new Vector3(0, 0, -1);
            ourBody.MovePosition(ourBody.position + transform.forward * vertical * speed * Time.fixedDeltaTime);*/

            anim.SetFloat(hash.speedFloat, -1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", true);
            
        }
        if (vertical == 0)
        {
            
            anim.SetFloat(hash.speedFloat, 0.0f);
            anim.SetBool(hash.backwardsBool, false);

          
        }

        // controlls horizontal
        if (horizontal > 0)
        {
            anim.SetBool(hash.strafeRightBool, true);

            //ourBody.MovePosition(ourBody.position + transform.right * horizontal * 5 * Time.fixedDeltaTime);
        }

        if (horizontal < 0)
        {
            anim.SetBool(hash.strafeLeftBool, true);    
            
            
            //ourBody.MovePosition(ourBody.position + transform.right * horizontal * 5 * Time.fixedDeltaTime);
        }

        if (horizontal == 0)
        {
            anim.SetBool(hash.strafeRightBool, false);
            anim.SetBool(hash.strafeLeftBool, false);         
        }
    }
}