using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessPlayerMovementScript : MonoBehaviour
{
    public float moveUpSpd = 5f;
    public float moveDownSpd = 1f;
    public float moveSideSpd = 5f;
    float moveVelocityLimit = 5f;
    float sinkVelocityLimit = 1f;

    Rigidbody2D rb;
    float moveX, moveY;
    bool canPlayerMove = true;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // rb.AddForce(Vector2.zero);
        InputListener();
    }

    void FixedUpdate()
    {
        PlayerControls();
    }

    void InputListener()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    void PlayerControls()
    {
        if (canPlayerMove == true)
        {
            if (moveX != 0 || moveY != 0)
            {
                if (moveX > 0) // PLAYER GOES RIGHT
                {
                    if (rb.velocity.x <= moveVelocityLimit)
                    {
                        rb.AddForce(transform.right * moveSideSpd);
                        rb.AddForce(transform.up * 0.05f);
                    }
                }
                else if (moveX < 0) // PLAYER GOES LEFT
                {
                    if (rb.velocity.x >= -moveVelocityLimit)
                    {
                        rb.AddForce(-transform.right * moveSideSpd);
                        rb.AddForce(transform.up * 0.05f);
                    }
                }
                else
                {
                    ;
                }

                if (moveY > 0) // PLAYER GOES UP
                {


                    if (rb.velocity.y <= moveVelocityLimit)
                    {
                        rb.AddForce(transform.up * moveUpSpd);
                    }

                }
                else if (moveY < 0) // PLAYER GOES DOWN
                {


                    if (rb.velocity.y >= -moveVelocityLimit)
                    {
                        rb.AddForce(-transform.up * moveDownSpd);
                    }

                }
                else
                {

                }
            }
            else
            {
            }
        }
    }
}
