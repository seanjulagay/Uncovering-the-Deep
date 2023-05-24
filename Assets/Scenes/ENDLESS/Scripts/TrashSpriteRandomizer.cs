using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashSpriteRandomizer : MonoBehaviour
{
    public List<Sprite> trashSprites = new List<Sprite>();

    void Start()
    {
        Debug.Log("Randomizing trash sprites");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = trashSprites[Random.Range(0, trashSprites.Count - 1)];
    }
}
