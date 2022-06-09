﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] Animator animatorBody;
    
    [SerializeField] Player player;

    private Vector2 movePosition;
    private float horizontal;
    private float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(animatorBody.GetCurrentAnimatorStateInfo(1));
        Move();
    }

    private void Move()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0 && vertical == 0) {
            rb.velocity = Vector2.zero;
            return;
        }

        movePosition = new Vector2(horizontal, vertical);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(horizontal, vertical) * (player.characterDefault.velocidad + 10) * Time.fixedDeltaTime;
        }
        else 
        { 
            rb.velocity = new Vector2(horizontal, vertical) * player.characterDefault.velocidad * Time.fixedDeltaTime;
        }
    }
}
