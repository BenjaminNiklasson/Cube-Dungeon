using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    float dmg;

    //[SerializeField] float rotateAfterBounce;
    //bool bounceBullet = true;
    //int numBounces = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dmg = GameObject.FindWithTag("Player").GetComponent<Weapon>().playerDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //numBounces--;

        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    collision.gameObject.GetComponent<EnemyDeath>().health = collision.gameObject.GetComponent<EnemyDeath>().health - dmg;
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    if (numBounces < 0)
        //     {
        //         var firstContact = collision.contacts[0];
        //         Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, firstContact.normal); 
        //         rb.velocity = reflectedVelocity;
        //         RotateTowardsVelocity();
        //     }
        //     else
        //     {
        //         Destroy(gameObject);
        //     }
        //}
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyDeath>().health = collision.gameObject.GetComponent<EnemyDeath>().health - dmg;
            Lifesteal();
        }
        Destroy(gameObject);
    }

    //void RotateTowardsVelocity()
    //{
    //    float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
    //    rb.angularVelocity = 0f;
    //    transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    //    Debug.Log("ResettingRotation");
    //}

    void Lifesteal()
    {
        FindFirstObjectByType<ScenePersist>().AddLifestealCounter();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}