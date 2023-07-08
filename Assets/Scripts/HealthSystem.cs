using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] private GameObject _RestartButton;
    
    private Animator _animator;
    public HealthBar _healthBar;

    public string sceneName;
    
    [SerializeField] private GameObject hitParticle;
    [SerializeField] private GameObject ragdoll;
    
    public int currentHealth;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        // _RestartButton.SetActive(false);
    }
    

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        _healthBar.SetHealth(currentHealth);
        _animator.SetTrigger("damage");

        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(ragdoll, transform.position, transform.rotation);
        Destroy(this.gameObject);
        Debug.Log("öldün");
        // _RestartButton.SetActive(true);
    }

    public void hitparticle(Vector3 hitPosition)
    {
        GameObject hit = Instantiate(hitParticle, hitPosition, quaternion.identity);
        Destroy(hit,3f);
    }

    // public void ButtonActionFonk()
    // {
    //     SceneManager.LoadScene(sceneName);
    //     _RestartButton.SetActive(false);
    // }

    
}
