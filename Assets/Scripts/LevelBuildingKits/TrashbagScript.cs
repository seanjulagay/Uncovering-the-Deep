using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashbagScript : MonoBehaviour
{
    TrashbagStackManager trashbagStackManager;

    Rigidbody2D rb;

    public bool isStacked = false;

    void Start()
    {
        trashbagStackManager = GameObject.Find("TrashbagStackManager").GetComponent<TrashbagStackManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && isStacked == false)
        {
            gameObject.tag = "TrashbagStacked";
            isStacked = true;
            trashbagStackManager.AddToStack(gameObject);
        }

        if ((other.gameObject.tag == "Terrain" || other.gameObject.tag == "Trashbag") && rb.velocity == new Vector2(0, 0))
        {
            gameObject.tag = "Trashbag";
            isStacked = false;
            trashbagStackManager.stackCount--;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {

    }
}
