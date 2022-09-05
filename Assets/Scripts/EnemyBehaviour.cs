using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using static UnityEngine.ParticleSystem;

public class EnemyBehaviour : MonoBehaviour, IDamagable
{
    [Header("Behaviour")]
    [HideInInspector] public Transform playerTransform;
    public AIPath AIPath;
    public AIDestinationSetter AIDestinationSetter;

    public float radius;
    public float radiusClose;
    public bool playerFound;
    public bool canMove;
    public LayerMask playerMask;

    [Header("Stats")]
    public int health;
    public int maxHealth;
    public bool isDead;

    [Header("Attack")]
    public GameObject bulletPrefab;
    public GameObject shootParticles;
    public Transform bulletStart;
    public int bulletDamage;
    public int bulletSpeed;
    public float attackSpeed;
    private float attackTime;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        AIDestinationSetter.target = playerTransform;
        health = maxHealth;
        attackTime = Time.time + attackSpeed;
    }
    public void Update()
    {
        if (playerTransform.GetComponent<PlayerHealth>().isDead)
        {
            DisableMove();
            return;
        }

        Move();
        if (playerFound && Time.time > attackTime)
        {
            Attack();
            attackTime = Time.time + attackSpeed;
        }
    }

    private void DisableMove()
    {
        canMove = false;
        AIPath.canMove = false;
    }
    public void Attack()
    {
        GameObject particle = Instantiate(shootParticles, bulletStart.position, Quaternion.identity, null);

        GameObject bulletInstance = Instantiate(bulletPrefab, bulletStart.position, Quaternion.identity, null);

        bulletInstance.GetComponent<BulletScript>().damage = bulletDamage;
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);

        Destroy(particle, particle.GetComponent<ParticleSystem>().main.duration);
    }
    public void Move()
    {
        if (!canMove) return;

        Collider2D player = Physics2D.OverlapCircle(transform.position, radius, playerMask);

        if (player != null)
        {
            playerFound = true;
            AIPath.enableRotation = false;

            Vector3 diff = playerTransform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        else
        {
            playerFound = false;
            AIPath.enableRotation = true;
        }

        float distance = Vector2.Distance(transform.position, playerTransform.position);

        if (distance < radiusClose)
        {
            AIPath.canMove = false;
        }
        else
        {
            AIPath.canMove = true;
        }
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
    public void CheckHealth()
    {
        if (health <= 0)
        {
            isDead = true;
            //Particles
            EnemySpawning.Instance.currentlySpawned--;
            GameManager.Instance.Score();
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (playerFound)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.yellow;
        }

        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, radiusClose);
    }
}
