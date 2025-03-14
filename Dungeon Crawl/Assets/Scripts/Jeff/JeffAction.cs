using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeffAction : MonoBehaviour
{
    [SerializeField] float eSpeed = 3f;
    Rigidbody2D rb;
    GameObject player;
    [SerializeField] GameObject Fist;
    [SerializeField] float fistCooldown = 2f;
    [SerializeField] float fistSpeed = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        Invoke("Attack", fistCooldown);
    }
    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * eSpeed * Time.fixedDeltaTime);
        }
    }

    private void Attack()
    {
        GameObject Attack = Instantiate(Fist, transform.position, Quaternion.identity);
        Rigidbody2D fistRb = Attack.GetComponent<Rigidbody2D>();
        Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 direcetion = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        fistRb.AddForce(new Vector2(direcetion.x + fistSpeed * Time.deltaTime, direcetion.y + fistSpeed * Time.deltaTime), ForceMode2D.Impulse);
        Invoke("Attack", fistCooldown);
    }
}
