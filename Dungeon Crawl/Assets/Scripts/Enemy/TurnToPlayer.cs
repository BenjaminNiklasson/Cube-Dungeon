using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class TurnToPlayer : MonoBehaviour
{
    GameObject playerCharacter;
    private void Start()
    {
        playerCharacter = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(playerCharacter.transform.position.x - transform.position.x, playerCharacter.transform.position.y - transform.position.y);
        transform.up = direction;
    }
}
