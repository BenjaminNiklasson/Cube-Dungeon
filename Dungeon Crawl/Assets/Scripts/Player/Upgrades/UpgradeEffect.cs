using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeEffect : MonoBehaviour
{
    enum Upgrades { lifesteal, MoreDamage, FasterBullets, SpreadShot, LessCooldown };
    [SerializeField] Upgrades _upgrades = new Upgrades();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (_upgrades)
        {
            case Upgrades.lifesteal:
                FindFirstObjectByType<ScenePersist>().IncreasLifesteal();
                break;
            case Upgrades.MoreDamage:
                FindFirstObjectByType<UpgradeManager>().AddUpgrade(UpgradeType.MoreDamage);
                break;
            case Upgrades.FasterBullets:
                FindFirstObjectByType<UpgradeManager>().AddUpgrade(UpgradeType.FasterBullets);
                break;
            case Upgrades.SpreadShot:
                FindFirstObjectByType<UpgradeManager>().AddUpgrade(UpgradeType.SpreadShot);
                break;
            case Upgrades.LessCooldown:
                FindFirstObjectByType<UpgradeManager>().AddUpgrade(UpgradeType.LessCooldown);
                break;
        }

        Destroy(gameObject);
    }
}
