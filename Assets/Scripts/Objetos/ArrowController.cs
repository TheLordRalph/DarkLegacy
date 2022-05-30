using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Vector3 target;
    public GameObject player;
    public Vector2 direction;
    private BoxCollider2D dimensions;
    
    // Start is called before the first frame update
    void Start()
    {
        dimensions = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, 0.01f);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        if (transform.position.x == target.x)
        {
            //Destroy(gameObject);
        }
        checkCollision();
    }
    private void checkCollision()
    {
        Vector2 topArrow = new Vector2(transform.position.x, transform.position.y);
        float playerXEndArea = player.transform.position.x + player.GetComponent<BoxCollider2D>().size.x / 2;
        float playerXfirstArea = player.transform.position.x - player.GetComponent<BoxCollider2D>().size.x / 2;
        float playeryEndArea = player.transform.position.y + player.GetComponent<BoxCollider2D>().size.y / 2;
        float playeryfirstArea = player.transform.position.y - player.GetComponent<BoxCollider2D>().size.y / 2;
        if (topArrow.x <= playerXEndArea && topArrow.x >= playerXfirstArea && topArrow.y <= playeryEndArea && topArrow.y >= playeryfirstArea)
        {
            Destroy(player);
        }
    }
}
