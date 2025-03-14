using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeffAction : MonoBehaviour
{
    [SerializeField] float eSpeed = 3f;
    Rigidbody2D rb;
    GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * eSpeed * Time.fixedDeltaTime);
        }
    }
}
