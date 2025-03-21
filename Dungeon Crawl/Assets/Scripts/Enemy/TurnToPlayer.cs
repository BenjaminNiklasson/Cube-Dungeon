using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class TurnToPlayer : MonoBehaviour
{
    [SerializeField] Transform playerCharacter;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(playerCharacter.position.x - transform.position.x, playerCharacter.position.y - transform.position.y);
        transform.up = direction;
    }
}
