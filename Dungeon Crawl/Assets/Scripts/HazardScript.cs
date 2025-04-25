using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    GameObject scenePersist;
    private void Start()
    {
        scenePersist = GameObject.FindWithTag("ScenePersist");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scenePersist.GetComponent<ScenePersist>().PlayerHurt();
        }
    }
}
