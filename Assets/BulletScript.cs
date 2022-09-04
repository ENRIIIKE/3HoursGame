using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [HideInInspector]
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamagable doDamage = collision.GetComponent<IDamagable>();

            doDamage.GetDamage(damage);
        }

        //Particles
        if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
