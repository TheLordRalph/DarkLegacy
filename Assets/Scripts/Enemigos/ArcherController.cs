using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    public GameObject player;
    public GameObject arrow;
    public float weaponBonus;
    public float typeDamageBonus;
    public String creatureType;
    public int vida;
    private AudioSource groaning1;
    private AudioSource groaning2;
    private AudioSource groaning3;
    private UnityEngine.AI.NavMeshAgent navmesh;
    private Vector2 smoothDeltaPosition;
    private Animator anim;
    private Vector2 velocity;
    private Vector2 enemyOrientation;
    private Boolean aliveBoolean = true;

    private float innerBowTime;
    /*
     0 --> idle
     1 --> walking
     */
    private float movementType;
    public float lookRadius;

    private void Awake()
    {

        navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        innerBowTime = Time.deltaTime;
        groaning1 = GetComponents<AudioSource>()[0];
        groaning2 = GetComponents<AudioSource>()[1];
        groaning3 = GetComponents<AudioSource>()[2];
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
                anim.SetFloat("Velocidad", movementType);
                anim.SetFloat("Horizontal", enemyOrientation.x);
                anim.SetFloat("Vertical", enemyOrientation.y);

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
        if ((innerBowTime - Time.deltaTime) > 2f)
        {
            GameObject newArrow = Instantiate(arrow, navmesh.transform.position, navmesh.transform.rotation);
            newArrow.GetComponent<ArrowController>().target = player.transform.position;
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
