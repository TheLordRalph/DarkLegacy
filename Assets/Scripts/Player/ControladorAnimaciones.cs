using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAnimaciones : MonoBehaviour
{

    private Animator anim;
    private Vector2 movePosition;
    private float horizontal;
    private float vertical;

    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private Player player;
    private bool animacionDeathActivada = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (playerControl.getVida() > 0)
        {
            Animacion();
        }
        else if (!animacionDeathActivada)
        {
            anim.SetBool("death", true);
            animacionDeathActivada = true;
        }
    }

    private void Animacion()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        movePosition = new Vector2(horizontal, vertical);

        anim.SetFloat("mouseX", Camera.main.ScreenToViewportPoint(Input.mousePosition).x);
        anim.SetFloat("mouseY", Camera.main.ScreenToViewportPoint(Input.mousePosition).y);

        anim.SetFloat("x", movePosition.x);
        anim.SetFloat("y", movePosition.y);


        if (horizontal != 0 || vertical != 0)
        {
            anim.SetInteger("velocidad", 1);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
            }
        }
        else
        {
            anim.SetInteger("velocidad", 0);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetFloat("clickX", Camera.main.ScreenToViewportPoint(Input.mousePosition).x);
            anim.SetFloat("clickY", Camera.main.ScreenToViewportPoint(Input.mousePosition).y);
            if (player.characterDefault.tipoAtaque.Equals("Attack"))
            {
                anim.SetBool("attack", true);
            }
            else if (player.characterDefault.tipoAtaque.Equals("Bow")) 
            {
                anim.SetBool("bow", true);
            }
            else if (player.characterDefault.tipoAtaque.Equals("Cast"))
            {
                anim.SetBool("cast", true);
            }
            
        }
        else
        {
            anim.SetBool("attack", false);
            anim.SetBool("bow", false);
            anim.SetBool("cast", false);
        }
    }
}
