using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int health;
    [SerializeField] string enemyType;

    // Start is called before the first frame update
    void Start()
    {
        switch (enemyType)
        {
            case "Jeff":
                health = 5;
                break;
            case "Shooter":
                health = 2;
                break;
            case "Swarmer":
                health = 1;
                break;
            case "Suicider":
                health = 3;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
