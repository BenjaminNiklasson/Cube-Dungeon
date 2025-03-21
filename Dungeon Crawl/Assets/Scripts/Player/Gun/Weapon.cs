using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    [SerializeField] float playerDamage = 10f;
    [SerializeField] float playerWeaponCooldown = 0.5f;
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject playerGun;

    private float nextFireTime = 0f;
    bool hasFired;

    //bool fasterBullets = false;
    //bool lessCooldown = false;
    //bool moreDamage = false;
    //bool bounceBullet = false;
    //bool spreadShot = false;
    //bool pierceBullet = false;
    //bool bulletLifeSteal = false;


    void Start()
    {
        
    }

    void OnFire()
    {
        if (!hasFired)
        {
            GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
            hasFired = true;
        }
    }
    void Update()
    {
        if (hasFired)
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
