using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    PlayerSpriteManagerScript playerSpriteManagerScript;
    TrashbagStackManager trashbagStackManager;

    Rigidbody2D rb;
    float moveX, moveY;
    public float moveUpSpd = 2f;
    public float moveDownSpd = 1f;
    public float moveSideSpd = 2f;
    float moveVelocityLimit = 3f;
    float sinkVelocityLimit = 1f;

    public bool canPlayerMove = true;

    void Start()
    {
        playerSpriteManagerScript = gameObject.GetComponent<PlayerSpriteManagerScript>();
        trashbagStackManager = GameObject.Find("TrashbagStackManager").GetComponent<TrashbagStackManager>();
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
                    }

                    if (trashbagStackManager.stackCount > 0) // PLAYER CARRYING
                    {
                        playerSpriteManagerScript.ChangePlayerSprite("oliveRightCarrying");
                    }
                    else
                    {
                        playerSpriteManagerScript.ChangePlayerSprite("oliveRightEmpty");
                    }
                }
                else if (moveX < 0) // PLAYER GOES LEFT
                {
                    if (rb.velocity.x >= -moveVelocityLimit)
                    {
                        rb.AddForce(-transform.right * moveSideSpd);
                    }

                    if (trashbagStackManager.stackCount > 0) // PLAYER CARRYING
                    {
                        playerSpriteManagerScript.ChangePlayerSprite("oliveLeftCarrying");
                    }
                    else
                    {
                        playerSpriteManagerScript.ChangePlayerSprite("oliveLeftEmpty");
                    }
                }

                if (moveY > 0) // PLAYER GOES UP
                {
                    if (rb.velocity.y <= moveVelocityLimit)
                    {
                        rb.AddForce(transform.up * moveUpSpd);
                    }

                    playerSpriteManagerScript.ChangePlayerSprite("oliveUp");
                }
                else if (moveY < 0) // PLAYER GOES DOWN
                {
                    if (rb.velocity.y >= -moveVelocityLimit)
                    {
                        rb.AddForce(-transform.up * moveDownSpd);
                    }

                    if (trashbagStackManager.stackCount > 0) // PLAYER CARRYING
                    {
                        playerSpriteManagerScript.ChangePlayerSprite("oliveDownCarrying");
                    }
                    else
                    {
                        playerSpriteManagerScript.ChangePlayerSprite("oliveDownEmpty");
                    }
                }
            }
            else
            {
                playerSpriteManagerScript.ChangePlayerSprite("oliveNeutral");
            }
        }
    }

}
