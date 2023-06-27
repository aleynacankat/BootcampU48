using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class EnemyDamageDealer : MonoBehaviour
{
    bool canDealDamage;
    bool hasDealtDamage;

    private HealthSystem _HealthSystem;
    
    public LayerMask _LayerMask;
    
    [SerializeField] float weaponLength;
    [SerializeField] int weaponDamage;
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = false;
    }
 
    
    void Update()
    {
        if (canDealDamage && !hasDealtDamage)
        {
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, _LayerMask))
            {
                if (hit.transform.TryGetComponent(out HealthSystem health))
                {
                    health.TakeDamage(weaponDamage);
                    Debug.Log("as");
                    hasDealtDamage = true;
                }
                
            }
        }
    }

   
    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage = false;
    }
    public void EndDealDamage()
    {
        canDealDamage = false;
    }
 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
        
    }
}