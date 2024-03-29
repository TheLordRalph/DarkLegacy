﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobSpawner : MonoBehaviour
{
    public GameObject mage;
    public GameObject warrior;
    public String spawnerType;
    private float innerSpawnerTime = 0;
    public float spawnTime;

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
            else if (spawnerType == "mage")
            {
                createmage();
            }
            innerSpawnerTime = 0;
        }
    }

    private void createmage()
    {
        GameObject newmage = Instantiate(mage, transform);
    }private void createWarrior()
    {
        GameObject newWarrior = Instantiate(warrior, transform.position, transform.rotation);
        newWarrior.GetComponent<EnemyController>().vida = 100;
    }
}
