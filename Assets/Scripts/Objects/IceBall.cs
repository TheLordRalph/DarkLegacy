using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{

    private Rigidbody2D rb;
    public Vector2 Target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target.x >= 0.0 && Target.x < 0.5 && Target.y == 0.0)
        {
            rb.velocity = new Vector2(-1, -1) * 100 * Time.deltaTime;
        }if (Target.x == 0.5 && Target.y == 0.0)
        {
            rb.velocity = new Vector2(-1, 0) * 100 * Time.deltaTime;
        }
        if (Target.x == 1.0 && Target.y == 0.0)
        {
            rb.velocity = new Vector2(-1, 1) * 100 * Time.deltaTime;
        }
        if (Target.x == 0.0 && Target.y == 0.5)
        {

        }if (Target.x == 0.5 && Target.y == 0.5)
        {

        }if (Target.x == 1.0 && Target.y == 0.5)
        {

        }if (Target.x == 0.0 && Target.y == 1.0)
        {

        }if (Target.x == 0.5 && Target.y == 1.0)
        {

        }if (Target.x == 1.0 && Target.y == 1.0)
        {

        }
    }
}
