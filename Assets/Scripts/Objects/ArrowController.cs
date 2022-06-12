using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Vector3 target;
    public GameObject player;
    public Vector2 direction;
    private float velocity = 0.06f;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, velocity);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (transform.position == target)
        {
            Destroy(gameObject);
        }
    }


    private void checkCollision()
    {
        /*Vector2 topArrow = new Vector2(transform.position.x, transform.position.y);
        float playerXEndArea = player.transform.position.x + player.GetComponent<BoxCollider2D>().size.x / 2;
        float playerXfirstArea = player.transform.position.x - player.GetComponent<BoxCollider2D>().size.x / 2;
        float playeryEndArea = player.transform.position.y + player.GetComponent<BoxCollider2D>().size.y / 2;
        float playeryfirstArea = player.transform.position.y - player.GetComponent<BoxCollider2D>().size.y / 2;
        if (topArrow.x <= playerXEndArea && topArrow.x >= playerXfirstArea && topArrow.y <= playeryEndArea && topArrow.y >= playeryfirstArea)
        {
            
        }*/
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject);
        if (other.name.StartsWith("Attack") || other.name == "Player")
        {
            other.gameObject.GetComponent<PlayerControl>().restarVida(damage);
        }
        Destroy(gameObject);
    }
}
