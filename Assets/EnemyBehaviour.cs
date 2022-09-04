using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform playerTransform;
    public AIPath AIPath;

    public float radius;
    public float radiusClose;
    public bool playerFound;
    public LayerMask playerMask;

    private void Update()
    {
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
