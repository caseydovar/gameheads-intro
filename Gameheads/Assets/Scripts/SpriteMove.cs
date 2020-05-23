using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteMove : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpForce = 10.0f;
    private float distanceToGround = 0.0f;
    private int jumpCount = 0;
    public Slider healthbar; 


    // Start is called before the first frame update
    void Start()
    {
       healthbar.value = 1.0f;
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentSpeed = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentSpeed -= speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentSpeed += speed;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            healthbar.value -= 0.1f;
        }

        rb.AddForce(new Vector2(currentSpeed * Time.deltaTime, 0.0f), ForceMode2D.Impulse);
        rb.AddForce(transform.forward * currentSpeed * Time.deltaTime, ForceMode2D.Impulse);

        bool isGrounded = IsGrounded();

        if (isGrounded)
        {
            jumpCount = 0;
        }

        if (Input.GetKey(KeyCode.Space) && (isGrounded || jumpCount < 2))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount = jumpCount + 1;
        }
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, distanceToGround + 0.1f);
    }
}