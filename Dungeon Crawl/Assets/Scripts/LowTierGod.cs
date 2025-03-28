using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowTierGod : MonoBehaviour
{
    [SerializeField] float killTimer = 1f;

    void Start()
    {
        Invoke("YouShouldKillYourselfNow", killTimer);
    }

    void YouShouldKillYourselfNow()
    {
        Destroy(gameObject);
    }
}
