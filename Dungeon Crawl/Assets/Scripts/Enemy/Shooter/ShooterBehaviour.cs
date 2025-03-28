using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBeaviour : MonoBehaviour
{
    [SerializeField] float eSpeed = 3f;
    Rigidbody2D rb;
    GameObject player;
    [SerializeField] GameObject Bullet;
    [SerializeField] float shootCooldown = 2f;
    bool tooCloseToPlayer = false;
    [SerializeField] float bulletSpeed = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        Invoke("Attack", shootCooldown);
    }
    void Update()
    {
        if (player != null && tooCloseToPlayer == false)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * eSpeed * Time.fixedDeltaTime);
        }
        else if (player != null && tooCloseToPlayer == true)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position - direction * eSpeed * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KeepAway"))
        {
            tooCloseToPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("KeepAway"))
        {
            tooCloseToPlayer = false;
        }
    }
    private void Attack()
    {
        GameObject Attack = Instantiate(Bullet, transform.position, transform.rotation);
        Attack.GetComponent<Rigidbody2D>().AddForce(Attack.transform.up * bulletSpeed);
        Invoke("Attack", shootCooldown);
    }
}
