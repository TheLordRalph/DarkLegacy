using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float weaponBonus;
    public float typeDamageBonus;
    public String creatureType;
    public int vida;
    private UnityEngine.AI.NavMeshAgent navmesh;
    private Vector2 smoothDeltaPosition;
    private Animator anim;
    private Vector2 velocity;
    private Vector2 enemyOrientation;
    private Boolean aliveBoolean = true;
    private AudioSource[] groaning;
    /*
     0 --> idle
     1 --> walking
     */
    private int movementType;
    private float lookRadius = 10f;

    private void Awake(){
        
		navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        navmesh.SetDestination(player.transform.position);
        groaning = GetComponents<AudioSource>();
    }

    // Start is called before the first frame update
    void Start(){
        navmesh.updateRotation = false;
        navmesh.updateUpAxis = false;
navmesh.updatePosition = false;
	}


    // Update is called once per frame
    void Update()
    {
        if (aliveBoolean)
        {
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
                        float damage = UnityEngine.Random.Range(100, 130);
                        damage += damage * (1 + weaponBonus) * (1 + typeDamageBonus);
                        print("'El jugador ha recibido " + damage + " daño'");
                    }
                }
            }
            
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
        Gizmos.DrawWireSphere(transform.position, navmesh.stoppingDistance);
    }
    void receiveDamage(int damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
            die();
        }
    }

    private void die()
    {
        System.Random a = new System.Random(groaning.Length);
        print(a);
    }
}
