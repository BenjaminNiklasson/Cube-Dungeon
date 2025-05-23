using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    SpreadShot,
    FasterBullets,
    LessCooldown,
    MoreDamage,
    //BounceBullet,
    //PierceBullet,
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

    [Header("Test Upgrades")]
    [SerializeField] private List<UpgradeEntry> testUpgrades = new List<UpgradeEntry>();

    private Dictionary<UpgradeType, int> upgrades = new Dictionary<UpgradeType, int>();

    private void Start()
    {
        ApplyInspectorUpgrades();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ApplyInspectorUpgrades();
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    public void AddUpgrade(UpgradeType type)
    {
        if (upgrades.ContainsKey(type))
            upgrades[type]++;
        else
            upgrades[type] = 1;
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
