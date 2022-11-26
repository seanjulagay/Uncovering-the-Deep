using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBubbleScript : MonoBehaviour
{
    public GameObject bubbleObj;
    public GameObject startPoint;
    public GameObject endPoint;

    Rigidbody2D bubbleRb;

    public float minWaitTime = 0;
    public float maxWaitTime = 5f;
    public float bubbleSpeed = 3f;

    void Start()
    {
        bubbleObj.SetActive(false);
        StartCoroutine(SpawnBubble());
    }

    public IEnumerator SpawnBubble()
    {
        float randomTime = Random.Range(minWaitTime, maxWaitTime);

        Debug.Log("randomTime: " + randomTime);

        yield return new WaitForSeconds(randomTime);

        Debug.Log("Waited for " + randomTime);

        bubbleObj.transform.position = new Vector2(bubbleObj.transform.position.x, startPoint.transform.position.y);
        bubbleObj.SetActive(true);
        bubbleObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bubbleSpeed);
    }

    void Update()
    {
        if (bubbleObj.transform.position.y >= endPoint.transform.position.y && bubbleObj.activeInHierarchy == true)
        {
            BubbleDestroyed();
        }
    }

    public void BubbleDestroyed()
    {
        Debug.Log("Bubble has been destroyed!");
        bubbleObj.SetActive(false);
        StartCoroutine(SpawnBubble());
    }
}
