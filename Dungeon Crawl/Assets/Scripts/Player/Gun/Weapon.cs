using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] public float playerBulletSpeed = 10f;
    [SerializeField] public float playerDamage = 10f;
    [SerializeField] private float playerWeaponCooldown = 7.5f;
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private GameObject playerGun;

    private float bulletSpreadDegrees = 15;
    private int numberOfBullets = 5;
    private float nextFireTime = 3.5f;
    private bool hasFired = false;

    void Start()
    {
        ApplyUpgrades();
    }
    private void ApplyUpgrades()
    {
        UpgradeManager upgrades = UpgradeManager.Instance;

        if (upgrades.fasterBullets)
        {
            playerBulletSpeed *= 1.5f; 
        }

        if (upgrades.lessCooldown)
        {
            playerWeaponCooldown *= 0.75f; 
        }

        if (upgrades.moreDamage)
        {
            playerDamage += 5; 
        }

        if (upgrades.spreadShot)
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
    }
    void OnFire()
    {
        if (!hasFired)
        {
            FireBullet(transform.rotation);
            hasFired = true;
        }
    }
    private void FireBullet(Quaternion rotation)
    {
        GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet.transform.up * playerBulletSpeed, ForceMode2D.Impulse);
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

