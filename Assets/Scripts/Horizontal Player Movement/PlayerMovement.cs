using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f; //fiddle with the speed and jumpforce to get a good feeling character
    public float maxSpeed = 10f;
    public float jumpForce;
    public AudioClip jumpSound;
    public AudioClip shootSound;
    
    private Rigidbody2D rb;
    private AudioSource source;
    private bool isGrounded; //add a boolean to check for whether the character is on the ground or not
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        //this automatically finds the required component on the object
        //this script is attached to and stores it in rb
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        if (source == null)
        {
            Debug.Log("Audio clip not found");
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        
    }

    void FixedUpdate() //used for physics, called every few frames
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A)) //left
        {
            rb.AddForce(new Vector2(-speed, 0) , ForceMode2D.Impulse);
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if (Input.GetKey(KeyCode.D)) //right
        {
            rb.AddForce(new Vector2(speed, 0) , ForceMode2D.Impulse);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        //limits the player's velocity to the maximum speed
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            if (rb.velocity.x < 0) //left movement
            {
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
            }
            else if (rb.velocity.x > 0) //right movement
            {
                rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            source.clip = jumpSound;
            source.Play();
            isGrounded = false;
        }
    }

    //trigger is detected when an object enters the collider, there are other
    //variations for when an object exits and stays in the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            anim.SetBool("isJumping", false);
            isGrounded = true;
        }

    }
}
