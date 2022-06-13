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

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.name == "Player")
        {
            print("Arrow: " + other.gameObject);
            other.gameObject.GetComponent<PlayerControl>().restarVida(damage);
            Destroy(gameObject);
        }
        
    }
}
