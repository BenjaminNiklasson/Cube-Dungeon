using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawn : MonoBehaviour
{
    public bool iSpawnTheChest = false;
    public bool dying = false;
    [SerializeField] GameObject chest;

    void Update()
    {
        if (iSpawnTheChest == true && dying == true)
        {
            Instantiate(chest, transform);
        }
    }
}
