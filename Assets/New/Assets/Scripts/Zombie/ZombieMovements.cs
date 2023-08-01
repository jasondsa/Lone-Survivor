using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovements : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    bool isDead = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > 2 && !isDead)
        {
            agent.updatePosition = true;
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
        }
        else
        {
            agent.updatePosition = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);

        }
    }
    public void EnemyDeathAnim()
    {
        isDead = true;
        anim.SetTrigger("isDead");
    }
}
