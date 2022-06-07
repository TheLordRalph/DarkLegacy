using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobSpawner : MonoBehaviour
{
    public GameObject archer;
    public GameObject warrior;
    public String spawnerType;
    private float innerSpawnerTime;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        innerSpawnerTime += Time.deltaTime;
        if ((innerSpawnerTime - Time.deltaTime) > spawnTime)
        {
            if (spawnerType == "warrior")
            {
                createWarrior();
            }
            else if (spawnerType == "archer")
            {
                createArcher();
            }
        }
    }

    private void createArcher()
    {
        GameObject newArcher = Instantiate(archer, transform);
    }private void createWarrior()
    {
        GameObject newWarrior = Instantiate(warrior, transform);
    }
}
