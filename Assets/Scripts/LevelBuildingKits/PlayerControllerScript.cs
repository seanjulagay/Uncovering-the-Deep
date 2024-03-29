using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControllerScript : MonoBehaviour
{
    public GameObject arrowKeysUI;
    UIArrowKeysScript uiArrowKeysScript;

    PlayerSpriteManagerScript playerSpriteManagerScript;
    TrashbagStackManager trashbagStackManager;
    SoundsManagerScript soundsManagerScript;

    Rigidbody2D rb;
    float moveX, moveY;
    public float moveUpSpd = 2f; // original value: 2f
    public float moveDownSpd = 1f;
    public float moveSideSpd = 2f;
    public float moveVelocityLimit = 5f; // original value: 3f
    float sinkVelocityLimit = 1f;

    public bool canPlayerMove = true;

    void Start()
    {
        try
        {
            arrowKeysUI = GameObject.Find("ArrowKeys");
            uiArrowKeysScript = arrowKeysUI.GetComponent<UIArrowKeysScript>();
            trashbagStackManager = GameObject.Find("TrashbagStackManager").GetComponent<TrashbagStackManager>();
            soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        playerSpriteManagerScript = gameObject.GetComponent<PlayerSpriteManagerScript>();

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
        try
        {
            if (canPlayerMove == true)
            {
                if (moveX != 0 || moveY != 0)
                {
                    soundsManagerScript.SoundEngine();
                    soundsManagerScript.SoundSwimming();
                    if (moveX > 0) // PLAYER GOES RIGHT
                    {
                        uiArrowKeysScript.ActivateArrow("right");
                        uiArrowKeysScript.DeactivateArrow("left");

                        if (rb.velocity.x <= moveVelocityLimit)
                        {
                            rb.AddForce(transform.right * moveSideSpd);
                            rb.AddForce(transform.up * 0.05f);
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
                        uiArrowKeysScript.ActivateArrow("left");
                        uiArrowKeysScript.DeactivateArrow("right");

                        if (rb.velocity.x >= -moveVelocityLimit)
                        {
                            rb.AddForce(-transform.right * moveSideSpd);
                            rb.AddForce(transform.up * 0.05f);
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

                        if (trashbagStackManager.stackCount > 0) // PLAYER CARRYING
                        {
                            playerSpriteManagerScript.ChangePlayerSprite("oliveDownCarrying");
                        }
                        else
                        {
                            playerSpriteManagerScript.ChangePlayerSprite("oliveDownEmpty");
                        }
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
                    soundsManagerScript.swimmingSound.Stop();
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

    }

}
