using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    [SerializeField] float playerDamage = 10f;
    [SerializeField] float playerWeaponCooldown = 7.5f;
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject playerGun;
    float bulletSpreadDegrees = 15;
    int numberOfBullets = 5;

    bool spreadShot = false;
    private float nextFireTime = 3.5f;
    bool hasFired = false;
    bool pierceBullet = false;
    bool bulletLifeSteal = false;
    bool fasterBullets = false;
    bool lessCooldown = false;
    bool moreDamage = false;
    bool bounceBullet = false;


    void Start()
    {
        //spreadShot = true;
    }

    void OnFire()
    {
        if (!hasFired)
        {
            if (spreadShot)
            {
                for (int i = 0; i < numberOfBullets; i++)
                {
                    float baseRotationZ = transform.rotation.eulerAngles.z;
                    float randomOffset = Random.Range(bulletSpreadDegrees, -bulletSpreadDegrees);
                    Quaternion bulletSpawnRotation = Quaternion.Euler(0, 0, baseRotationZ + randomOffset);
                    GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, bulletSpawnRotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(bullet.transform.up * playerBulletSpeed, ForceMode2D.Impulse);
                    hasFired = true;
                }
            }
            else
            {
                GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
                hasFired = true;
            }
        }
    }
    void Update()
    {
        if (hasFired == true)
        {
            nextFireTime += Time.deltaTime;
            if (nextFireTime > playerWeaponCooldown)
            {
                hasFired = false;
                nextFireTime = 0;
            }
        }
    }
}

