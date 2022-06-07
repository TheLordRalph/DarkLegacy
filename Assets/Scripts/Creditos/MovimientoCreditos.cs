using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoCreditos : MonoBehaviour
{

    private RectTransform transform;
    private Boolean empezarCreditos = false;

    void Start()
    {
        transform = GetComponent<RectTransform>();
        StartCoroutine("Wait");
    }

    void Update()
    {
        if (empezarCreditos) 
        { 
        
            if (!(transform.position.y >= 4350))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            }
            else
            {
                SceneManager.LoadScene(0);
            }

            if (Input.GetAxisRaw("Cancel") == 1)
            {
                SceneManager.LoadScene(0);
            }

        }
    }

    IEnumerator Wait() 
    {
        yield return new WaitForSeconds(3);
        empezarCreditos = true;
    }
}