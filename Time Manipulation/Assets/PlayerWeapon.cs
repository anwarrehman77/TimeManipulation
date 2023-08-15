using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject firePoint, bulletPrefab;

    [SerializeField]
    private float shotCooldown = 3f;
    [SerializeField]
    private float launchForce = 30f;
    private float nextShotTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (Time.time >= nextShotTime))
        {
            Shoot();
            nextShotTime = Time.time + shotCooldown;
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(newBullet.transform.rotation.y) * launchForce, 0f);
    }
}
