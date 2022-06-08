using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    private Rigidbody2D rb;
    
    public float velocidad;
    private Vector2 movePosition;
    private float horizontal;
    private float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
        rb.velocity = new Vector2(horizontal, vertical) * velocidad * Time.fixedDeltaTime;
    }

    
}
