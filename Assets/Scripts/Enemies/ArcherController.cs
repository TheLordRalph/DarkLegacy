using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    private GameObject player;
    public GameObject spell;
    public float weaponBonus;
    public float typeDamageBonus;
    public String creatureType;
    public int vida;
    public int dannoArma;
    private AudioSource groaning1;
    private AudioSource groaning2;
    private AudioSource groaning3;
    private UnityEngine.AI.NavMeshAgent navmesh;
    private Vector2 smoothDeltaPosition;
    private Animator anim;
    private Vector2 velocity;
    private Vector2 enemyOrientation;
    private Boolean aliveBoolean = true;

    private AudioSource[] groaning;
    private float innerBowTime;
    private Boolean soundPlaying = false;
    /*
     0 --> idle
     1 --> walking
     */
    private float movementType;
    public float lookRadius = 10f;

    private void Awake()
    {

        navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        innerBowTime = Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player");
        groaning = GetComponents<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        navmesh.updateRotation = false;
        navmesh.updateUpAxis = false;
        navmesh.updatePosition = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (aliveBoolean)
        {
            navmesh.SetDestination(player.transform.position);
            innerBowTime += Time.deltaTime;
            float distance = Vector2.Distance(player.transform.position, navmesh.transform.position);
            if (distance < lookRadius)
            {
                CalculateEnemyOrientation();



                // Update animation parameters
                /* anim.SetFloat("Velocidad", movementType);
                 anim.SetFloat("Horizontal", enemyOrientation.x);
                 anim.SetFloat("Vertical", enemyOrientation.y);*/

                navmesh.SetDestination(player.transform.position);

                if (distance <= navmesh.stoppingDistance)
                {
                    if (creatureType.ToLower().Equals("goblin"))
                    {
                        /*
                         *Trigger combat animation
                         *
                         **/
                        shootAtPlayer();
                    }
                }
            }
        }
    }

    private void shootAtPlayer()
    {
        if ((innerBowTime - Time.deltaTime) > 5f)
        {
            GameObject newArrow = Instantiate(spell, navmesh.transform.position, navmesh.transform.rotation);
            newArrow.GetComponent<ArrowController>().target = player.transform.position;
            newArrow.GetComponent<ArrowController>().damage = dannoArma;
            newArrow.GetComponent<ArrowController>().direction = navmesh.transform.position - player.transform.position;
            newArrow.GetComponent<ArrowController>().player = player;
            innerBowTime = 0;
        }
        else
        {
            //print(innerBowTime - Time.deltaTime);
        }
    }

    private void CalculateEnemyOrientation()
    {
        if (Math.Round(navmesh.transform.position.x, 2) == Math.Round(player.transform.position.x, 2))
        {
            enemyOrientation.x = 0;
            movementType = 0;
        }
        else if (Math.Round(navmesh.transform.position.x, 2) > Math.Round(player.transform.position.x, 2))
        {
            enemyOrientation.x = -1;
            movementType = 1;
        }
        else if (Math.Round(navmesh.transform.position.x, 2) < Math.Round(player.transform.position.x, 2))
        {
            enemyOrientation.x = 1;
            movementType = 1;
        }
        if (Math.Round(navmesh.transform.position.y, 2) == Math.Round(player.transform.position.y, 2))
        {
            enemyOrientation.y = 0;
            movementType = 0;
        }
        else if (Math.Round(navmesh.transform.position.y, 2) > Math.Round(player.transform.position.y, 2))
        {
            enemyOrientation.y = -1;
            movementType = 1;
        }
        else if (Math.Round(navmesh.transform.position.y, 2) < Math.Round(player.transform.position.y, 2))
        {
            enemyOrientation.y = 1;
            movementType = 1;
        }
    }

    void OnAnimatorMove()
    {
        // Update position to agent position
        transform.position = navmesh.nextPosition;
    }
    public void receiveDamage(int damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
            die();
        }
    }
    private void die()
    {
        int a = UnityEngine.Random.Range(0, groaning.Length);
        for (int i = 0; i < groaning.Length; i++)
        {
            if (groaning[i].isPlaying)
            {
                soundPlaying = true;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
