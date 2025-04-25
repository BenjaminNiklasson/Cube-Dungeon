using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]Vector2 moveInput;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float rotateSpeed = 2000f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }



    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveInput * moveSpeed;

        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveInput);
            Quaternion rotate = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            rb.MoveRotation(rotate);
            Debug.Log("moveing");
        }
        else
        {
            rb.angularVelocity = 0;
        }
    }
}
