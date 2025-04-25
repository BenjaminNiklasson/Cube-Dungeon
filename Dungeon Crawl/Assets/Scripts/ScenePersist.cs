using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int playerHealthMax = 10;
    [SerializeField] float invincibilityTime = 1f;
    bool invincible = false;
    int playerHealth;
    float lifestealAmount = 0;
    GameObject player;
    Vector3 startSpawnPlayer;
    int lifeStealCounter;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = playerHealthMax;
        startSpawnPlayer = player.transform.position;
    }
    private void Awake()
    {
        int numScenePersist = FindObjectsByType<ScenePersist>(FindObjectsSortMode.None).Length;
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayerHurt()
    {
        if (invincible == false)
        {
            if (playerHealth > 1)
            {
                playerHealth--;
                invincible = true;
                Invoke("TurnOffInvincible", invincibilityTime);
            }
            else if (playerLives > 0)
            {
                playerHealth = playerHealthMax;
                playerLives--;
                player.transform.position = startSpawnPlayer;
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void AddLifestealCounter()
    {
        for (int i = 0; i < lifestealAmount; i++)
        {
            lifeStealCounter++;
            if (lifeStealCounter >= 3 && playerHealthMax !<= playerHealth)
            {
                playerHealth++;
            }
        }
    }

    private void TurnOffInvincible()
    {
        invincible = false;
    }
}
