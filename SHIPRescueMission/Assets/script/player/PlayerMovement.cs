using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip shoutingClip;
    public float speedDampTime = 0.01f;
    public float sensitivityX = 4.0f;
    public float pitchValue;

    private Animator anim;
    private HashIDs hash;

    private float elapsedTime = 0;
    private bool noBackMov = true;
  
    private void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        anim.SetLayerWeight(1, 1f);
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        bool sneak = Input.GetButton("Sneak");
        float turn = Input.GetAxis("Turn");

        Rotating(turn);
        MovementManager(v,sneak);

        elapsedTime += Time.deltaTime;
    }
    private void Update()
    {
        bool shout = Input.GetButtonDown("Attract");
        anim.SetBool(hash.shoutingBool, shout);
        AudioManagement(shout);
    }

    void MovementManager(float vertical, bool sneaking)
    {        
        
        anim.SetBool(hash.sneakingBool, sneaking);

        if (vertical > 0)
        {
            anim.SetFloat(hash.speedFloat, 1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", false);
            noBackMov = true;

            Rigidbody ourBody = this.GetComponent<Rigidbody>();

            float movement = Mathf.Lerp(0f, 0.04f, elapsedTime);
            Vector3 moveForward = new Vector3(0.0f, 0.0f, movement);
            moveForward = ourBody.transform.TransformDirection(moveForward);
            ourBody.transform.position += moveForward;
        }
        if (vertical < 0)
        {
            if (noBackMov == true)
            {
                elapsedTime = 0;
                noBackMov = false;
            }

            anim.SetFloat(hash.speedFloat, -1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", true);

            Rigidbody ourBody = this.GetComponent<Rigidbody>();

            float movement = Mathf.Lerp(0f, -0.025f, elapsedTime);
            Vector3 moveBack = new Vector3(0.0f, 0.0f, movement);
            moveBack = ourBody.transform.TransformDirection(moveBack);
            ourBody.transform.position += moveBack;
        }
        if (vertical == 0)
        {
            anim.SetFloat(hash.speedFloat, 0.01f);
            anim.SetBool(hash.backwardsBool, false);
            noBackMov = true;
        }
    }

    void Rotating(float mouseXInput)
    {
        Rigidbody ourbody = this.GetComponent<Rigidbody>();

        if (mouseXInput != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, mouseXInput * sensitivityX, 0f);

            ourbody.MoveRotation(ourbody.rotation * deltaRotation);
        }
    }
    
    void AudioManagement(bool shout)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().pitch = 0.5f;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
       
        
        if (shout)
        {
            AudioSource.PlayClipAtPoint(shoutingClip, transform.position);

            GameObject thisAudio = GameObject.Find("One shot audio");

            if (thisAudio.name == "Z2-V2-Angry-Free-1")
            {
                thisAudio.GetComponent<AudioSource>().pitch = pitchValue;
            }
        }
        
    }
}
