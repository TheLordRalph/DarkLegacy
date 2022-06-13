using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
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
    private Boolean soundPlaying = false;
    /*
     0 --> idle
     1 --> walking
     */
    private int movementType;
    private float lookRadius = 4f;
    private float innerAttackTime;

    private void Awake()
    {

        navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        //navmesh.SetDestination(player.transform.position);

        innerAttackTime = Time.deltaTime;
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

            innerAttackTime += Time.deltaTime;
            float distance = Vector2.Distance(player.transform.position, navmesh.transform.position);
            /* Debug.Log("distance: " + distance);
             print(distance < lookRadius);*/
            if (distance < lookRadius)
            {
                CalculateEnemyOrientation();



                // Update animation parameters
                 anim.SetInteger("velocidad", movementType);
                 anim.SetFloat("mouseX", enemyOrientation.x);
                 anim.SetFloat("mouseY", enemyOrientation.y);
                anim.SetFloat("x", enemyOrientation.x);
                anim.SetFloat("y", enemyOrientation.y);

                navmesh.SetDestination(player.transform.position);

                if (distance <= navmesh.stoppingDistance)
                {
                    if (creatureType.ToLower().Equals("goblin"))
                    {
                        if ((innerAttackTime - Time.deltaTime) > 5f)
                        {
                            anim.SetBool("attack", true);

                            anim.SetFloat("clickX", enemyOrientation.x);
                            anim.SetFloat("clickY", enemyOrientation.y);
                            float damage = UnityEngine.Random.Range(3, 8);
                            damage += damage * (1 + weaponBonus) * (1 + typeDamageBonus);
                            player.GetComponent<PlayerControl>().restarVida(damage);
                            //print("'El jugador ha recibido " + damage + " daño'");
                            innerAttackTime = 0;
                        }
                        else
                        {
                            anim.SetBool("attack", false);
                        }
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
        float distance = Vector2.Distance(player.transform.position, navmesh.transform.position);
        if (distance <= navmesh.stoppingDistance) movementType = 0;
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
        Destroy(gameObject);
    }
}
