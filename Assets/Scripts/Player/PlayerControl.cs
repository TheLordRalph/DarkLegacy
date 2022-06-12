using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] SpriteRenderer body;
    [SerializeField] Player player;
    [SerializeField] GameObject[] atacks;


    private Vector2 movePosition;
    private float horizontal;
    private float vertical;


    private float vida;
    private bool isAttack = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        vida = player.characterDefault.vida;
    }


    void Update()
    {
        if (getVida() > 0 && !body.sprite.name.StartsWith("2_Attack") && !body.sprite.name.StartsWith("3_Bow") && !body.sprite.name.StartsWith("4_Cast"))
        {
            if (isAttack) 
            { 
                desactivateAttack();
                isAttack = false;
            }
            move();
        }
        else
        {
            rb.velocity = Vector2.zero;
            atack();
        }


    }


    private void atack() 
    {
        if (body.sprite.name.Contains("CAM0")) 
        {
            atacks[0].SetActive(true);
            isAttack = true;
        }
        else if (body.sprite.name.Contains("CAM1"))
        {
            atacks[1].SetActive(true);
            isAttack = true;
        }
        else if (body.sprite.name.Contains("CAM2"))
        {
            atacks[2].SetActive(true);
            isAttack = true;
        }
        else if (body.sprite.name.Contains("CAM3"))
        {
            atacks[3].SetActive(true);
            isAttack = true;
        }
        else if (body.sprite.name.Contains("CAM4"))
        {
            atacks[4].SetActive(true);
            isAttack = true;
        }
        else if (body.sprite.name.Contains("CAM5"))
        {
            atacks[5].SetActive(true);
            isAttack = true;
        }
        else if (body.sprite.name.Contains("CAM6"))
        {
            atacks[6].SetActive(true);
            isAttack = true;
        }
        else if (body.sprite.name.Contains("CAM7"))
        {
            atacks[7].SetActive(true);
            isAttack = true;
        }
    }

    private void desactivateAttack() 
    {
        foreach (GameObject g in atacks)
        {
            g.SetActive(false);
        }
    }

    private void move()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0 && vertical == 0)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        movePosition = new Vector2(horizontal, vertical);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(horizontal, vertical) * (player.characterDefault.velocidad + 15) * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = new Vector2(horizontal, vertical) * player.characterDefault.velocidad * Time.fixedDeltaTime;
        }
    }


    public void restarVida(float daño) 
    {
        this.vida -= daño;
        Debug.Log(this.vida);
    }

    public float getVida() 
    {
        return this.vida;
    }
}
