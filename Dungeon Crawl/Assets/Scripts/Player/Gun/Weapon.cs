using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject playerBullet;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpreadDegrees = 10f;
    [SerializeField] private GameObject playerGun;
    private int numberOfBullets = 1;
    public float playerBulletSpeed = 5f;
    public float playerWeaponCooldown = 0.5f;
    public float playerDamage = 1f;

    bool hasFired = false;
    float nextFireTime = 0f;

    private void Start()
    {
        StartCoroutine(ApplyUpgradesWithDelay());
    }

    private void Update()
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

        if (Input.GetButtonDown("Fire1") && !hasFired)
        {
            OnFire();
        }
    }

    public void ApplyUpgrades()
    {
        var upgrades = UpgradeManager.Instance;
        if (upgrades == null) return;

        if (upgrades.HasUpgrade(UpgradeType.LessCooldown))
        {
            playerWeaponCooldown -= 0.05f * upgrades.GetStackCount(UpgradeType.LessCooldown);
        }

        if (upgrades.HasUpgrade(UpgradeType.MoreDamage))
        {
            playerDamage += 1f * upgrades.GetStackCount(UpgradeType.MoreDamage);
        }

        if (upgrades.HasUpgrade(UpgradeType.FasterBullets))
        {
            playerBulletSpeed += 1f * upgrades.GetStackCount(UpgradeType.FasterBullets);
        }
    }
    private void OnFire()
    {
        var upgrades = UpgradeManager.Instance;

        numberOfBullets = upgrades?.HasUpgrade(UpgradeType.SpreadShot) == true
            ? 1 + upgrades.GetStackCount(UpgradeType.SpreadShot)
            : 1;

        FireBullet(Quaternion.identity);
        hasFired = true;
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
    private IEnumerator ApplyUpgradesWithDelay()
    {
        yield return null;

        var upgrades = UpgradeManager.Instance;
        if (upgrades == null) yield break;

        if (upgrades.HasUpgrade(UpgradeType.LessCooldown))
        {
            playerWeaponCooldown = Mathf.Max(0.1f, playerWeaponCooldown - 0.05f * upgrades.GetStackCount(UpgradeType.LessCooldown));
        }

        if (upgrades.HasUpgrade(UpgradeType.MoreDamage))
        {
            playerDamage += 1f * upgrades.GetStackCount(UpgradeType.MoreDamage);
        }

        if (upgrades.HasUpgrade(UpgradeType.FasterBullets))
        {
            playerBulletSpeed += 1f * upgrades.GetStackCount(UpgradeType.FasterBullets);
        }

        Debug.Log($"Cooldown: {playerWeaponCooldown}, Damage: {playerDamage}, Bullet Speed: {playerBulletSpeed}");
    }

}
