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
        int randomNum = Random.Range(0, 2);
        trashbagStackManager = GameObject.Find("TrashbagStackManager").GetComponent<TrashbagStackManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && isStacked == false)
        {
            Debug.Log("DETECTED PROPERLY");
            gameObject.tag = "TrashbagStacked";
            isStacked = true;
            trashbagStackManager.AddToStack(gameObject);
        }
    }

    // void OnCollisionStay2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Player" && isStacked == false)
    //     {
    //         gameObject.tag = "TrashbagStacked";
    //         isStacked = true;
    //         trashbagStackManager.AddToStack(gameObject);
    //     }
    // }

    // void MaintainY() {
    //     if()
    // }
}
