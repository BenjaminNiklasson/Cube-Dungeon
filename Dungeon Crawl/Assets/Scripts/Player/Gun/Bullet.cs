using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] float rotateAfterBounce;
    bool bounceBullet = true;
    int numBounces = 2;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bounceBullet && numBounces > 0)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyDeath>().health--;
                Destroy(gameObject);
            }
            else
            {
                ContactPoint2D contact = collision.contacts[0];
                Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, contact.normal);
                rb.velocity = reflectedVelocity;
                Invoke("RotateTowardsVelocity", rotateAfterBounce);
                numBounces--;   
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }

    void RotateTowardsVelocity()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Debug.Log("ResettingVelocity");
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}