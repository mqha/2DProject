using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 5f;
    public float jumpForce = 500f;

    private Rigidbody2D rigidbody2D;

    private float horizontal = 0f;
    private float vertical = 0f;

    private float eulerAngelY = 0f;
    private bool horizontalDown = false;

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

        horizontalDown = horizontal != 0;
        eulerAngelY = horizontal < 0 ? 180 : 0;

        if (horizontalDown)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, eulerAngelY, transform.eulerAngles.z);
        }

        if (onJumpKey)
            Jump();
    }

    private void Jump()
    {
        rigidbody2D.AddForce(transform.up *jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }
}
