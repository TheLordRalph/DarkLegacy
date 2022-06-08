using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAnimaciones : MonoBehaviour
{

    private Animator anim;
    private Vector2 movePosition;
    private float horizontal;
    private float vertical;

<<<<<<< HEAD
    // Start is called before the first frame update
=======

>>>>>>> Raul
    void Start()
    {
        anim = GetComponent<Animator>();
    }

<<<<<<< HEAD
    // Update is called once per frame
=======
    
>>>>>>> Raul
    void Update()
    {
        Animacion();
    }

    private void Animacion()
    {

<<<<<<< HEAD
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        movePosition = new Vector2(horizontal, vertical);

=======
>>>>>>> Raul
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetFloat("clickX", Camera.main.ScreenToViewportPoint(Input.mousePosition).x);
            anim.SetFloat("clickY", Camera.main.ScreenToViewportPoint(Input.mousePosition).y);
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetFloat("clickX", Camera.main.ScreenToViewportPoint(Input.mousePosition).x);
            anim.SetFloat("clickY", Camera.main.ScreenToViewportPoint(Input.mousePosition).y);
            anim.SetBool("bow", true);
        }
        else
        {
            anim.SetBool("bow", false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetFloat("clickX", Camera.main.ScreenToViewportPoint(Input.mousePosition).x);
            anim.SetFloat("clickY", Camera.main.ScreenToViewportPoint(Input.mousePosition).y);
            anim.SetBool("cast", true);
        }
        else
        {
            anim.SetBool("cast", false);
        }


        if (Input.GetKey(KeyCode.J))
        {
            anim.SetBool("death", true);
        }
    }
<<<<<<< HEAD
=======

>>>>>>> Raul
}
