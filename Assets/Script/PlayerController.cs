using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float jumpForce = 500f;

    private Rigidbody2D rigidbody2D;

    private float horizontal = 0f;
    private float vertical = 0f;

    private bool onJumpKey = false;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.position += Vector3.right * moveSpeed * Time.deltaTime * horizontal;

        onJumpKey = Input.GetKeyDown(KeyCode.Space);

        if (onJumpKey)
            Jump();
    }

    private void Jump()
    {
        rigidbody2D.AddForce(transform.up *jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }
}
