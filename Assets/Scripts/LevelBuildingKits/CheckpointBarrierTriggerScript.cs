using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBarrierTriggerScript : MonoBehaviour
{
    public string oliveDialogue;

    GameObject playerObj;
    GameObject barrierRedirector;
    Rigidbody2D playerRb;

    PlayerControllerScript playerControllerScript;
    UIManagerScript uiManagerScript;

    bool redirectPlayer = false;
    float redirectorForce = 0.5f;

    void Start()
    {
        oliveDialogue = "I should pick up all the trash here first!";

        playerObj = GameObject.Find("Player");
        barrierRedirector = gameObject.transform.parent.Find("CheckpointBarrierRedirector").gameObject;
        playerRb = playerObj.GetComponent<Rigidbody2D>();

        playerControllerScript = playerObj.GetComponent<PlayerControllerScript>();
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
    }

    void Update()
    {
        RedirectPlayerRigidbody();
        RedirectPlayer();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Something's in the trigger!");
        if (other.gameObject.tag == "Player")
        {
            redirectPlayer = true;
            playerControllerScript.canPlayerMove = false;
            uiManagerScript.OliveDialogue(oliveDialogue);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            redirectPlayer = false;
            playerControllerScript.canPlayerMove = true;
        }
    }

    void RedirectPlayer()
    {
        if (redirectPlayer == true)
        {
            Debug.Log("Player movement temporarily disabled");
        }
    }

    void RedirectPlayerRigidbody()
    {
        if (redirectPlayer == true)
        {
            float directionX = barrierRedirector.transform.position.x - playerObj.transform.position.x;
            float directionY = barrierRedirector.transform.position.y - playerObj.transform.position.y;

            if (directionX < 0) // redirector is at left of player
            {
                playerRb.AddForce(transform.right * -redirectorForce, 0);
            }
            else if (directionX > 0) // redirector is at right of player
            {
                playerRb.AddForce(transform.right * redirectorForce, 0);
            }

            if (directionY < 0) // redirector is at bottom of player
            {
                playerRb.AddForce(transform.up * -redirectorForce, 0);
            }
            else if (directionY > 0) // redirector is at top of player
            {
                playerRb.AddForce(transform.up * redirectorForce, 0);
            }
        }
    }
}
