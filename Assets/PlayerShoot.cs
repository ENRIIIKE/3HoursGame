using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPosition;

    [Space]
    public float bulletSpeed;
    public int bulletDamage;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        //Particles

        GameObject bulletInstance = Instantiate(bulletPrefab, shootPosition.position, Quaternion.identity, null);

        bulletInstance.GetComponent<BulletScript>().damage = bulletDamage;
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
