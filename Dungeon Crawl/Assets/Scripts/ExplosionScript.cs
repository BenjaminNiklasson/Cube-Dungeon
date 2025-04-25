using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    GameObject scenePersist;
    private void Start()
    {
        scenePersist = GameObject.FindWithTag("ScenePersist");
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scenePersist.GetComponent<ScenePersist>().PlayerHurt();
        }
    }
}
