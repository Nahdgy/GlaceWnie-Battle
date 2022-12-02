using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControllerVanillaIcy : MonoBehaviour
{
   
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    public float jumpForce;
   
    
    [SerializeField]
    private bool isJumping;
    [SerializeField]
    private bool isGrounded;
    
    [SerializeField]
    private Transform groundCheckLeft;
    [SerializeField]
    private Transform groundCheckRight;

    [SerializeField]
    public Rigidbody2D rb;
    [SerializeField]
    public CapsuleCollider2D vanillaIcyCollider;
    private Vector3 velocity = Vector3.zero;


    public Animator animator;
   

   
    [SerializeField]
    public GameObject bulletDiag;
    [SerializeField]
    public GameObject bulletRight;
    [SerializeField]
    public GameObject bulletUp;
  
    [SerializeField]
    public Transform shootUp;
    [SerializeField]
    public Transform shootRight;
    [SerializeField]
    public Transform shootDiag;

    [SerializeField]
    private float health;
    [SerializeField]
    public static PlayerControllerVanillaIcy instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        
        MovePlayer(horizontalMovement);

        bool isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            bool jumping = Input.GetButton("Jump");
            JumpPlayer(jumping);
            UnityEngine.Debug.Log(isGrounded);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            bool shooting = Input.GetButton("Fire1");
            ShootIce(bulletDiag,shootDiag);
            UnityEngine.Debug.Log(isGrounded);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            bool shooting = Input.GetButton("Fire2");
            ShootIce(bulletUp,shootUp);
            UnityEngine.Debug.Log(isGrounded);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            bool shooting = Input.GetButton("Fire3");
            ShootIce(bulletRight,shootRight);
            UnityEngine.Debug.Log(isGrounded);
        }
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }

    void JumpPlayer(bool _jumping)
    {
        rb.AddForce(new Vector2(0f, jumpForce));

    }

    void ShootIce(GameObject bullet, Transform shootPosition)
    {
       Instantiate(bullet, shootPosition.position, Quaternion.identity);
    }

    


  
}