using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBarrierTriggerScript : MonoBehaviour
{
    GameObject playerObj;
    GameObject barrierRedirector;
    Rigidbody2D playerRb;

    PlayerControllerScript playerControllerScript;
    UIManagerScript uiManagerScript;

    string oliveDialogue;
    bool redirectPlayer = false;
    float redirectorForceX = 0.6f;
    float redirectorForceY = 0.6f;

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            redirectPlayer = true;
            // playerControllerScript.canPlayerMove = false;
            // uiManagerScript.OliveDialogue(oliveDialogue);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            redirectPlayer = false;
            // playerControllerScript.canPlayerMove = true;
        }
    }

    void RedirectPlayer()
    {
        if (redirectPlayer == true)
        {
            // Debug.Log("Player movement temporarily disabled");
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
                playerRb.AddForce(transform.right * -redirectorForceX, 0);
                Debug.Log("LEFT");
            }
            else if (directionX > 0) // redirector is at right of player
            {
                playerRb.AddForce(transform.right * redirectorForceX, 0);
                Debug.Log("RIGHT");
            }

            if (directionY < 0) // redirector is at bottom of player
            {
                playerRb.AddForce(transform.up * -redirectorForceY, 0);
                Debug.Log("BOTTOM");
            }
            else if (directionY > 0) // redirector is at top of player
            {
                playerRb.AddForce(transform.up * redirectorForceY, 0);
                Debug.Log("UP");
            }
        }
    }
}
