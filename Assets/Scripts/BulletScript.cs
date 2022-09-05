using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [HideInInspector]
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamagable>() != null)
        {
            IDamagable doDamage = collision.GetComponent<IDamagable>();

            doDamage.GetDamage(damage);
        }

        if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
