using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] bulletPrefabs;
    [SerializeField] GameObject firePoint;
    [SerializeField] private float shotCooldown = 3f;
    [SerializeField] private float launchForce = 30f;
    
    private float nextShotTime = 0f;
    private int selectedBulletIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) selectedBulletIndex = selectedBulletIndex < bulletPrefabs.Length - 1 ? selectedBulletIndex + 1 : selectedBulletIndex;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) selectedBulletIndex = selectedBulletIndex > 0 ? selectedBulletIndex - 1 : 0;

        if (Input.GetMouseButtonDown(0) && (Time.time >= nextShotTime))
        {
            Shoot();
            nextShotTime = Time.time + shotCooldown;
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefabs[selectedBulletIndex], firePoint.transform.position, firePoint.transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(newBullet.transform.rotation.y) * launchForce, 0f);
    }
}
