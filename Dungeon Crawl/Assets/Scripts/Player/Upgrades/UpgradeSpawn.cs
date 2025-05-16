using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> _upgrades = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(_upgrades[Random.Range(1,7)]);
    }
}
