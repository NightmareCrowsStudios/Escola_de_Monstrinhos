﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float runSpeed;
    private Rigidbody2D rb;
    private bool facingRight = true;

    //variaveis para joystick
    private float horizontalMove = 0f;
    public Joystick joystick;
    public float runSpeedHorizontal = 2f;

    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        FixedUpdate();
    }

    void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0 , 0) * Time.deltaTime * speed;

        if(horizontalMove < 0)
        {
            anim.Play("IdleEsquerda");
        } else
        {
            anim.Play("Idle");
        }

        //float moveInput = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        /*if(facingRight == false && horizontalMove > 0)
        {
            Flip();
        } else if(facingRight && horizontalMove < 0)
        {
            Flip();
        }*/

        /*if(horizontalMove > 0)
        {
            transform.eulerAngles = new Vector3(0f,0f,0f); //olhando para direita
        }
        if(horizontalMove < 0)
        {
            transform.eulerAngles = new Vector3(0f,180f,0f); //olhando para esquerda
        }*/

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if(transform.position.y < -5.30f)
        {
            SceneManager.LoadScene(3);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Jump()
    {
        if(rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            //rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void Run()
    {
        if(rb.velocity.y == 0)
        {
            transform.position += new Vector3(horizontalMove, 0 , 0) * Time.deltaTime * runSpeed;
        }
    }
}
