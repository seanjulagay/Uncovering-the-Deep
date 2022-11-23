using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public Sprite oliveUp;
    public Sprite oliveDown;
    public Sprite oliveLeft;
    public Sprite oliveRight;

    SpriteRenderer mySprite;

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
        if (moveX != 0 || moveY != 0)
        {
            if (moveX > 0 && (rb.velocity.x <= moveVelocityLimit)) // PLAYER GOES RIGHT
            {
                Debug.Log("Going Right");
                rb.AddForce(transform.right * moveSideSpd);
                gameObject.GetComponent<SpriteRenderer>().sprite = oliveRight;
            }
            else if (moveX < 0 && (rb.velocity.x >= -moveVelocityLimit)) // PLAYER GOES LEFT
            {
                Debug.Log("Going Left");
                rb.AddForce(-transform.right * moveSideSpd);
                gameObject.GetComponent<SpriteRenderer>().sprite = oliveLeft;
            }

            if (moveY > 0 && (rb.velocity.y <= moveVelocityLimit)) // PLAYER GOES UP
            {
                Debug.Log("Goin' up!");
                rb.AddForce(transform.up * moveUpSpd);
                gameObject.GetComponent<SpriteRenderer>().sprite = oliveUp;
            }
            else if (moveY < 0) // PLAYER GOES DOWN
            {
                if (rb.velocity.y >= -moveVelocityLimit)
                {
                    Debug.Log("Going down");
                    rb.AddForce(-transform.up * moveDownSpd);
                }
                gameObject.GetComponent<SpriteRenderer>().sprite = oliveDown;
            }
        }
        else
        {
            // if (gameObject.GetComponent<Rigidbody2D>().velocity.y. =>
            gameObject.GetComponent<SpriteRenderer>().sprite = oliveUp;
        }
    }

}
