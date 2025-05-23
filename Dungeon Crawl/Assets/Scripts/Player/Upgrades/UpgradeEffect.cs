using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeEffect : MonoBehaviour
{
    enum Upgrades { lifesteal, damage, bulletSpeed, bulletCount, cooldown, pierce };
    [SerializeField] Upgrades _upgrades = new Upgrades();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (_upgrades)
        {
            case Upgrades.lifesteal:
                FindFirstObjectByType<ScenePersist>().IncreasInt("lifesteal");
                break;
            case Upgrades.damage:
                FindFirstObjectByType<ScenePersist>().IncreasInt("damage");
                break;
            case Upgrades.bulletSpeed:
                FindFirstObjectByType<ScenePersist>().IncreasInt("bulletSpeed");
                break;
            case Upgrades.bulletCount:
                FindFirstObjectByType<ScenePersist>().IncreasInt("bulletCount");
                break;
            case Upgrades.cooldown:
                FindFirstObjectByType<ScenePersist>().IncreasInt("cooldown");
                break;
            case Upgrades.pierce:
                FindFirstObjectByType<ScenePersist>().IncreasInt("pierce");
                break;
        }

        Destroy(gameObject);
    }
}
