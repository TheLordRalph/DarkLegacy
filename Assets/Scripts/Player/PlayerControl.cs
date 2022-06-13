using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] SpriteRenderer body;
    [SerializeField] Player player;
    [SerializeField] GameObject[] atacks;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject gameOver_UI;
    [SerializeField] GameObject cast;


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

        if (player.characterDefault.tipoAtaque != "Attack") 
        {
            weapon.SetActive(false);
        }
    }


    void Update()
    {
        if (getVida() <= 0) 
        {
            rb.velocity = Vector2.zero;
            gameOver();
        }

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
            //habilidad();
        }


    }

    private void gameOver() 
    {
        gameOver_UI.SetActive(true);
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("PJ: " + other.gameObject);
        if (other.gameObject.name == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().receiveDamage(player.characterDefault.fuerza);
        }
        else if (other.gameObject.name == "Archer")
        {
            other.gameObject.GetComponent<ArcherController>().receiveDamage(player.characterDefault.fuerza);
        }
    }

    private void habilidad() 
    {
        print(Input.mousePosition);
        print(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        GameObject newArrow = Instantiate(cast, transform.position, transform.rotation);
        newArrow.GetComponent<IceBall>().Target = Camera.main.ScreenToViewportPoint(Input.mousePosition);
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
            rb.velocity = new Vector2(horizontal, vertical) * (player.characterDefault.velocidad + 10) * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = new Vector2(horizontal, vertical) * player.characterDefault.velocidad * Time.fixedDeltaTime;
        }
    }


    public void restarVida(float daño) 
    {
        this.vida -= daño;
        print(this.vida);
    }

    public float getVida() 
    {
        return this.vida;
    }
}
