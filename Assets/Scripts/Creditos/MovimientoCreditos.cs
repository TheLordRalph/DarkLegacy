using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoCreditos : MonoBehaviour
{

    private Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
    }


    void Update()
    {
        
        if (!(transform.position.y == 4350))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 2);
        }

        if (Input.GetAxisRaw("Cancel") == 1)
        {
            SceneManager.LoadScene(0);
        }
    }

}