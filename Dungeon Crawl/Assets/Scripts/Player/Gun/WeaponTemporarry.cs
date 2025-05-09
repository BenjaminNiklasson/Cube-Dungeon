using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTemporarry : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    //[SerializeField] float playerShootingSpeed = 10f;
    //[SerializeField] float playerWeaponCooldown = 10f;
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject playerGun;
    float bulletSpreadDegrees = 15;
    int numberOfBullets = 5;

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
        Debug.Log("Is Calling OnFire");
        for (int i = 0; i < numberOfBullets; i++)
        {
            Debug.Log("Is Shooting");
            float baseRotationZ = transform.rotation.eulerAngles.z;
            float randomOffset = Random.Range(bulletSpreadDegrees, -bulletSpreadDegrees);
            Quaternion bulletSpawnRotation = Quaternion.Euler(0, 0, baseRotationZ + randomOffset);
            GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, bulletSpawnRotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.up * playerBulletSpeed, ForceMode2D.Impulse);
        }
    }
    void Update()
    {

    }
}

