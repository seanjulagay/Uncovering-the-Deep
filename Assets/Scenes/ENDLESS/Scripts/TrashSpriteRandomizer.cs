using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashSpriteRandomizer : MonoBehaviour
{
    List<Sprite> trashSprites = new List<Sprite>();

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = trashSprites[Random.Range(0, trashSprites.Count - 1)];
    }
}
