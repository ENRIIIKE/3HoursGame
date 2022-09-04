using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public int health;
    public int maxHealth;

    void Start()
    {
        health = maxHealth;
    }
    public void GetDamage(int damage)
    {
        if (damage > health)
        {
            health = 0;
        }
        else
        {
            health -= damage;
        }

        //Particles

        CheckHealth();
    }
    private void CheckHealth()
    {
        if (health <= 0)
        {
            //Particles
            //Player Dead
        }
    }
}
