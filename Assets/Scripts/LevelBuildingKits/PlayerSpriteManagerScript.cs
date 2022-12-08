using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteManagerScript : MonoBehaviour
{
    public Sprite oliveDownCarrying, oliveDownEmpty, oliveLeftCarrying, oliveLeftEmpty, oliveNeutral, oliveRightCarrying, oliveRightEmpty, oliveUp;

    public GameObject playerColliderUpright, playerColliderSideways, playerSpriteUpright, playerSpriteLeft, playerSpriteRight;

    BoxCollider2D colUpright;
    BoxCollider2D colSideways;

    SpriteRenderer spriteUpright; // SpriteRenderer of PlayerSpriteUpright object
    SpriteRenderer spriteLeft; // SpriteRenderer of PlayerSpriteLeft object
    SpriteRenderer spriteRight; // SpriteRenderer of PlayerSpriteRight object

    public void Start()
    {
        colUpright = GameObject.Find("PlayerColliderUpright").GetComponent<BoxCollider2D>();
        colSideways = GameObject.Find("PlayerColliderSideways").GetComponent<BoxCollider2D>();
        spriteUpright = GameObject.Find("PlayerSpriteUpright").GetComponent<SpriteRenderer>();
        spriteLeft = GameObject.Find("PlayerSpriteLeft").GetComponent<SpriteRenderer>();
        spriteRight = GameObject.Find("PlayerSpriteRight").GetComponent<SpriteRenderer>();
    }

    public void ChangePlayerSprite(string oliveStatus)
    {
        // Debug.Log("ChangePlayerSprite called");
        switch (oliveStatus)
        {
            case "oliveDownCarrying":
                ColSprUpright();
                spriteUpright.sprite = oliveDownCarrying;
                break;
            case "oliveDownEmpty":
                ColSprUpright();
                spriteUpright.sprite = oliveDownEmpty;
                break;
            case "oliveLeftCarrying":
                ColSprLeft();
                spriteLeft.sprite = oliveLeftCarrying;
                break;
            case "oliveLeftEmpty":
                ColSprLeft();
                spriteLeft.sprite = oliveLeftCarrying;
                break;
            case "oliveNeutral":
                ColSprUpright();
                spriteUpright.sprite = oliveNeutral;
                break;
            case "oliveRightCarrying":
                ColSprRight();
                spriteRight.sprite = oliveRightCarrying;
                break;
            case "oliveRightEmpty":
                ColSprRight();
                spriteRight.sprite = oliveRightEmpty;
                break;
            case "oliveUp":
                ColSprUpright();
                spriteUpright.sprite = oliveUp;
                break;
            default:
                Debug.Log("Error on ChangePlayerSprite");
                break;
        }
    }

    void ColUprActive()
    {
        colUpright.enabled = true;
        colSideways.enabled = false;
    }

    void ColSideActive()
    {
        colUpright.enabled = false;
        colSideways.enabled = true;
    }

    void SprUprightActive()
    {
        spriteUpright.enabled = true;
        spriteLeft.enabled = false;
        spriteRight.enabled = false;
    }

    void SprLeftActive()
    {
        spriteUpright.enabled = false;
        spriteLeft.enabled = true;
        spriteRight.enabled = false;
    }

    void SprRightActive()
    {
        spriteUpright.enabled = false;
        spriteLeft.enabled = false;
        spriteRight.enabled = true;
    }

    void ColSprUpright()
    {
        ColUprActive();
        SprUprightActive();
    }

    void ColSprLeft()
    {
        ColSideActive();
        SprLeftActive();
    }

    void ColSprRight()
    {
        ColSideActive();
        SprRightActive();
    }
}
