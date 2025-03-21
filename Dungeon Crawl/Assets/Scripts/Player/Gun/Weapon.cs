using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    //[SerializeField] float playerShootingSpeed = 10f;
    //[SerializeField] float playerWeaponCooldown = 10f;
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject playerGun;

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
        GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * playerBulletSpeed, ForceMode2D.Impulse);
    }
    void Update()
    {
        
    }
}
