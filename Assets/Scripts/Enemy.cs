using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 3;
    [SerializeField] private GameObject hitParticle;
    [SerializeField] private GameObject ragdoll;
    
    [Header("Combat")] 
    [SerializeField] private float attackCD = 3f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] private float aggroRange = 4f;
    
    private GameObject player;
    private NavMeshAgent agent;
    private Animator _animator;

    private float timePassed;
    private float newDestinationCD = 0.5f;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);

        if (timePassed >= attackCD)
        {
            if (Vector3.Distance(player.transform.position,transform.position) <= attackRange)
            {
                _animator.SetTrigger("attack");
                timePassed = 0;
            }
        }
        timePassed += Time.deltaTime;

        if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
        {
            newDestinationCD = 0.5f;
            agent.SetDestination(player.transform.position);
        }
        newDestinationCD -= Time.deltaTime;
        transform.LookAt(player.transform);
    }
    
    void Die()
    {
        Instantiate(ragdoll, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
    
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        _animator.SetTrigger("damage");

        if (health <= 0)
        {
            Die();
        }
    }
    
    public void hitparticle(Vector3 hitPosition)
    {
        GameObject hit = Instantiate(hitParticle, hitPosition, Quaternion.identity);
        Destroy(hit,3f);
    }
    
    public void StartDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
    }

    public void EndDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
