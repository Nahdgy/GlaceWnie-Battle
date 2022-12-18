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
    private int nbSauts;
    [SerializeField]
    private int ground = 6;
    [SerializeField] 
    private int nbMaxSauts;

    [SerializeField]
    private bool isJumping = false;
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
    Animator anim;

    [SerializeField]
    private float health;
    [SerializeField]
    public static PlayerControllerVanillaIcy instance;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if(Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position))
        {
            isGrounded = true;
        } 
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        
        MovePlayer(horizontalMovement);

        float _palyerVelocity = Mathf.Abs(rb.velocity.x);
        anim.SetFloat("Speed",_palyerVelocity);

        
       

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
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

        if(isJumping == true)
        {
           JumpPlayer(rb);
            isJumping = false;
        }
    }

    void JumpPlayer(bool _jumping)
    {
        if (nbSauts >= nbMaxSauts)
        {
            return;
        }
        rb.AddForce(transform.up * jumpForce);
        nbSauts++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == ground)
        {
            isGrounded = true;
            nbSauts = 0;
        }
    }

    private void ShootIce(GameObject bullet, Transform shootPosition)
    {
       Instantiate(bullet, shootPosition.position, Quaternion.identity);
    }
}