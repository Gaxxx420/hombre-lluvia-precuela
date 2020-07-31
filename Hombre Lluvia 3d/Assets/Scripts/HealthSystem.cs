using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    protected float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }

    protected void Heal(float amount)
    {
        currentHealth -= amount;
    }
}
