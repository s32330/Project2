using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float health = 100;
    // public Animator anim;

    public bool isDead = false;

    private PlayerAnimator _animator;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        _animator = GetComponent<PlayerAnimator>();
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        _animator.TriggerHurt();
        if (health < 0) 
        { 
            health = 0; 
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health == 0) 
        { 
            isDead = true;
            _animator.TriggerDeath();

            /*na lekcji 9.05.202
             anim.SetTrigger("IsDead");
            */
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
