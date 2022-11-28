using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBoundsScript : MonoBehaviour
{
    GameObject playerObj;
    Rigidbody2D playerRb;

    void Start()
    {
        playerObj = GameObject.Find("Player");
        playerRb = playerObj.GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        playerRb.AddForce(new Vector2(-playerRb.velocity.x * 20, -playerRb.velocity.y * 20));
    }
}
