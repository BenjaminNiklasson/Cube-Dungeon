using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float despawnTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        Invoke("DestroySelf", despawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
