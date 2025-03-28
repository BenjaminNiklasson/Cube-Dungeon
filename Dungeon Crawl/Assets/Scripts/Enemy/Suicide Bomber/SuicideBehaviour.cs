using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    [SerializeField] float eSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * eSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {

        }
    }
}
