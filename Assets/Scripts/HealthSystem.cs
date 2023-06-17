using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;

    
    private Animator _animator;
    public HealthBar _healthBar;

    public int currentHealth;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;  
        
    }
    

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        _healthBar.SetHealth(currentHealth);
        
        _animator.SetTrigger("damage");

        if (maxHealth == 0)
        {
            
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
