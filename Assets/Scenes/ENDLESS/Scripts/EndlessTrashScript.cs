using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTrashScript : MonoBehaviour
{
    EndlessGameManager endlessGameManager;

    void Awake()
    {
        endlessGameManager = GameObject.Find("EndlessGameManager").GetComponent<EndlessGameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(endlessGameManager.gameObject.name);
            endlessGameManager.playerScore++;
            Destroy(this.gameObject);
        }
    }

    // void StartAnimation()
    // {
    //     float timer = 0f;
    //     while (timer < slideDuration)
    //     {
    //         Debug.Log("SLIDING DOWN");
    //         timer += Time.deltaTime;
    //         float t = Mathf.Clamp01(timer / slideDuration);
    //         transform.position = Vector3.Lerp(startPosition, targetPosition, t);
    //     }

    //     timer = 0f;
    //     while (timer < retractDelay)
    //     {
    //         Debug.Log("WAITING FOR RETRACT");
    //         timer += Time.deltaTime;
    //     }

    //     timer = 0f;
    //     while (timer < retractDuration)
    //     {
    //         Debug.Log("RETRACTING");
    //         timer += Time.deltaTime;
    //         float t = Mathf.Clamp01(timer / retractDuration);
    //         transform.position = Vector3.Lerp(targetPosition, startPosition, t);
    //     }
    // }
}
