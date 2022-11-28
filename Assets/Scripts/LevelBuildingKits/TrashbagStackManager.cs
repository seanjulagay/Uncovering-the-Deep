using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashbagStackManager : MonoBehaviour
{
    public GameObject playerObj;
    public int stackCount = 0;

    float trashbagHeight;
    float playerTop;

    public void AddToStack(GameObject trashbag)
    {
        Rigidbody2D trashbagRb = trashbag.GetComponent<Rigidbody2D>();
        trashbagHeight = trashbag.transform.localScale.y;
        playerTop = playerObj.transform.position.y + (playerObj.transform.localScale.y / 2);

        stackCount++;

        trashbagRb.constraints = RigidbodyConstraints2D.None;
        trashbagRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        trashbag.transform.position = new Vector2(playerObj.transform.position.x, playerTop + (trashbagHeight * stackCount));
    }
}
