using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] public float playerBulletSpeed = 10f;
    [SerializeField] public float playerDamage = 10f;
    [SerializeField] private float playerWeaponCooldown = 7.5f;
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private GameObject playerGun;

    private float bulletSpreadDegrees = 2f;
    private int numberOfBullets = 1;
    private float nextFireTime = 0f;
    private bool hasFired = false;

    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ApplyUpgrades();
    }
    private void ApplyUpgrades()
    {
        UpgradeManager upgrades = UpgradeManager.Instance;

        // Increase bullet speed by +5 per stack
        playerBulletSpeed += upgrades.GetStackCount(UpgradeType.FasterBullets) * 5f;

        // Increase damage by +5 per stack
        playerDamage += upgrades.GetStackCount(UpgradeType.MoreDamage) * 5f;

        // Reduce cooldown by 10% per stack (multiplicative)
        int cooldownStacks = upgrades.GetStackCount(UpgradeType.LessCooldown);
        playerWeaponCooldown *= Mathf.Pow(0.75f, cooldownStacks);

        // SpreadShot: +2 bullets per stack, +1° spread per stack
        if (upgrades.HasUpgrade(UpgradeType.SpreadShot))
        {
            int spreadStacks = upgrades.GetStackCount(UpgradeType.SpreadShot);
            numberOfBullets = 1 + spreadStacks * 2;
            bulletSpreadDegrees = 3f + spreadStacks;
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
        float baseRotationZ = transform.rotation.eulerAngles.z;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float spreadOffset = 0f;

            if (numberOfBullets > 1)
            {
                float totalSpread = bulletSpreadDegrees * (numberOfBullets - 1);
                spreadOffset = -totalSpread / 2f + bulletSpreadDegrees * i;
            }

            Quaternion bulletRotation = Quaternion.Euler(0, 0, baseRotationZ + spreadOffset);
            GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, bulletRotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.up * playerBulletSpeed, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        if (hasFired)
        {
            nextFireTime += Time.deltaTime;
            if (nextFireTime >= playerWeaponCooldown)
            {
                hasFired = false;
                nextFireTime = 0f;
            }
        }
    }
}
