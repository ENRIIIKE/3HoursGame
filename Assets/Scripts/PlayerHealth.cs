using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public int health;
    public int maxHealth;
    public bool isDead;

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

        GameManager.Instance.Health(health);

        CheckHealth();
    }
    private void CheckHealth()
    {
        if (health <= 0)
        {
            isDead = true;
            GetComponent<PlayerController>().canMove = false;
            GameManager.Instance.EndGame();
        }
    }
}
