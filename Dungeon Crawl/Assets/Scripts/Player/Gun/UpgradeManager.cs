using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UIElements;

public enum UpgradeType
{
    SpreadShot,
    PierceBullet,
    BulletLifeSteal,
    FasterBullets,
    LessCooldown,
    MoreDamage,
    BounceBullet
}

[System.Serializable]
public class UpgradeEntry
{
    public UpgradeType type;
    public int stackCount = 0;
}

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    [Header("Test Upgrades (Editable in Inspector)")]
    [SerializeField] private List<UpgradeEntry> testUpgrades = new List<UpgradeEntry>();

    private Dictionary<UpgradeType, int> upgrades = new Dictionary<UpgradeType, int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ApplyInspectorUpgrades(); // load the inspector values
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Reads values from inspector list into the real upgrades dictionary
    private void ApplyInspectorUpgrades()
    {
        upgrades.Clear();

        foreach (UpgradeEntry entry in testUpgrades)
        {
            if (entry.stackCount > 0)
            {
                upgrades[entry.type] = entry.stackCount;
            }
        }
    }

    // Use this if you want to add more upgrades dynamically during runtime
    public void AddUpgrade(UpgradeType type)
    {
        if (upgrades.ContainsKey(type))
        {
            upgrades[type]++;
        }
        else
        {
            upgrades[type] = 1;
        }
    }

    public bool HasUpgrade(UpgradeType type)
    {
        return upgrades.ContainsKey(type);
    }

    public int GetStackCount(UpgradeType type)
    {
        return upgrades.TryGetValue(type, out int count) ? count : 0;
    }
}

