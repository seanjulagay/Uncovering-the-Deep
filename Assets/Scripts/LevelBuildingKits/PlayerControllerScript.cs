using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    Rigidbody2D rb;
    float moveX, moveY;
    public float moveUpSpd = 2f;
    public float moveDownSpd = 1f;
    public float moveSideSpd = 2f;
    float moveVelocityLimit = 3f;
    float sinkVelocityLimit = 1f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
        if (moveX > 0 && (rb.velocity.x <= moveVelocityLimit))
        {
            Debug.Log("Going Right");
            rb.AddForce(transform.right * moveSideSpd);
        }
        else if (moveX < 0 && (rb.velocity.x >= -moveVelocityLimit))
        {
            Debug.Log("Going Left");
            rb.AddForce(-transform.right * moveSideSpd);
        }

        if (moveY > 0 && (rb.velocity.y <= moveVelocityLimit))
        {
            Debug.Log("Goin' up!");
            rb.AddForce(transform.up * moveUpSpd);
        }
        else if (moveY < 0 && (rb.velocity.y >= -moveVelocityLimit))
        {
            Debug.Log("Going down");
            rb.AddForce(-transform.up * moveDownSpd);
        }
    }


}
