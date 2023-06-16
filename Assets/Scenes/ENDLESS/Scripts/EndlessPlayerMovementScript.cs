using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndlessPlayerMovementScript : MonoBehaviour
{
    PlayerSpriteManagerScript playerSpriteManagerScript;
    UIArrowKeysScript uiArrowKeysScript;
    SoundsManagerScript soundsManagerScript;

    public float moveUpSpd = 2f;
    public float moveDownSpd = 1f;
    public float moveSideSpd = 2f;
    public float moveVelocityLimit = 5f;
    float sinkVelocityLimit = 1f;

    Rigidbody2D rb;
    float moveX, moveY;
    bool canPlayerMove = true;

    Image playerSprite;

    void Start()
    {
        playerSpriteManagerScript = GameObject.Find("Player").GetComponent<PlayerSpriteManagerScript>();
        uiArrowKeysScript = GameObject.Find("ArrowKeys").GetComponent<UIArrowKeysScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerSprite = GameObject.Find("Player").GetComponent<Image>();
        soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();
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
        try
        {
            if (canPlayerMove == true)
            {
                if (moveX != 0 || moveY != 0)
                {
                    soundsManagerScript.SoundEngine();
                    if (moveX > 0) // PLAYER GOES RIGHT
                    {
                        uiArrowKeysScript.ActivateArrow("right");
                        uiArrowKeysScript.DeactivateArrow("left");

                        if (rb.velocity.x <= moveVelocityLimit)
                        {
                            rb.AddForce(transform.right * moveSideSpd);
                            rb.AddForce(transform.up * 0.05f);
                        }

                        playerSpriteManagerScript.ChangePlayerSprite("oliveRightEmpty");

                    }
                    else if (moveX < 0) // PLAYER GOES LEFT
                    {
                        uiArrowKeysScript.ActivateArrow("left");
                        uiArrowKeysScript.DeactivateArrow("right");

                        if (rb.velocity.x >= -moveVelocityLimit)
                        {
                            rb.AddForce(-transform.right * moveSideSpd);
                            rb.AddForce(transform.up * 0.05f);
                        }

                        playerSpriteManagerScript.ChangePlayerSprite("oliveLeftEmpty");

                    }
                    else
                    {
                        uiArrowKeysScript.DeactivateArrow("left");
                        uiArrowKeysScript.DeactivateArrow("right");
                    }

                    if (moveY > 0) // PLAYER GOES UP
                    {
                        uiArrowKeysScript.ActivateArrow("up");
                        uiArrowKeysScript.DeactivateArrow("down");

                        if (rb.velocity.y <= moveVelocityLimit)
                        {
                            rb.AddForce(transform.up * moveUpSpd);
                        }

                        playerSpriteManagerScript.ChangePlayerSprite("oliveUp");
                    }
                    else if (moveY < 0) // PLAYER GOES DOWN
                    {
                        uiArrowKeysScript.ActivateArrow("down");
                        uiArrowKeysScript.DeactivateArrow("up");

                        if (rb.velocity.y >= -moveVelocityLimit)
                        {
                            rb.AddForce(-transform.up * moveDownSpd);
                        }

                        playerSpriteManagerScript.ChangePlayerSprite("oliveDownEmpty");

                    }
                    else
                    {
                        uiArrowKeysScript.DeactivateArrow("up");
                        uiArrowKeysScript.DeactivateArrow("down");
                    }
                }
                else
                {
                    soundsManagerScript.engineSound.Stop();
                    uiArrowKeysScript.DeactivateArrow("left");
                    uiArrowKeysScript.DeactivateArrow("up");
                    uiArrowKeysScript.DeactivateArrow("right");
                    uiArrowKeysScript.DeactivateArrow("down");
                    if (rb.velocity.y >= 0)
                    {
                        playerSpriteManagerScript.ChangePlayerSprite("oliveNeutral");
                    }
                    else
                    {
                        playerSpriteManagerScript.ChangePlayerSprite("oliveDownCarrying");
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        // void PlayerControls()
        // {
        //     if (canPlayerMove == true)
        //     {
        //         if (moveX != 0 || moveY != 0)
        //         {
        //             if (moveX > 0) // PLAYER GOES RIGHT
        //             {
        //                 playerSprite.sprite = playerSpriteManagerScript.oliveRightEmpty;
        //                 if (rb.velocity.x <= moveVelocityLimit)
        //                 {
        //                     rb.AddForce(transform.right * moveSideSpd);
        //                     rb.AddForce(transform.up * 0.05f);
        //                 }
        //             }
        //             else if (moveX < 0) // PLAYER GOES LEFT
        //             {
        //                 playerSprite.sprite = playerSpriteManagerScript.oliveLeftEmpty;
        //                 if (rb.velocity.x >= -moveVelocityLimit)
        //                 {
        //                     rb.AddForce(-transform.right * moveSideSpd);
        //                     rb.AddForce(transform.up * 0.05f);
        //                 }
        //             }
        //             else
        //             {
        //                 ;
        //             }

        //             if (moveY > 0) // PLAYER GOES UP
        //             {
        //                 playerSprite.sprite = playerSpriteManagerScript.oliveUp;
        //                 if (rb.velocity.y <= moveVelocityLimit)
        //                 {
        //                     rb.AddForce(transform.up * moveUpSpd);
        //                 }

        //             }
        //             else if (moveY < 0) // PLAYER GOES DOWN
        //             {
        //                 playerSprite.sprite = playerSpriteManagerScript.oliveDownEmpty;
        //                 if (rb.velocity.y >= -moveVelocityLimit)
        //                 {
        //                     rb.AddForce(-transform.up * moveDownSpd);
        //                 }

        //             }
        //         }
        //     }
        // }
    }
}

