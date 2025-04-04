using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public static UpgradeManager Instance { get; private set; }

    [Header("Upgrades Enabled")]
    [SerializeField] public bool spreadShot = false;
    [SerializeField] public bool pierceBullet = false;
    [SerializeField] public bool bulletLifeSteal = false;
    [SerializeField] public bool fasterBullets = false;
    [SerializeField] public bool lessCooldown = false;
    [SerializeField] public bool moreDamage = false;
    [SerializeField] public bool bounceBullet = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {

    }
    void Update()
    {

    }
}