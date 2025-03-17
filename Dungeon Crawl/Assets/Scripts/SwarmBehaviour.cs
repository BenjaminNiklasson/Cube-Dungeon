using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmerBehaviour : MonoBehaviour
{
    [SerializeField] float enemySpeed = 2f;
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
            Vector2 direction = new Vector2(transform.up.x, transform.up.y);
            rb.MovePosition(rb.position + (direction * enemySpeed * Time.fixedDeltaTime));
            //Vector2 direction = (player.transform.position - transform.position).normalized;
            //rb.MovePosition(rb.position + (direction * enemySpeed * Time.fixedDeltaTime));
        }
    }
}