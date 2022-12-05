using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPropertiesScript : MonoBehaviour
{
    Rigidbody2D rb;

    public static float oxygenCount = 99f;
    public float playerScore;
    public bool underwater = false;

    float oxygenReplenishRate = 5f;

    void Start()
    {
        Debug.Log("Loaded PlayeRProps");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerOxygenHandler();
        PlayerPhysicsHandler();
    }

    void PlayerOxygenHandler()
    {
        if (underwater == true && oxygenCount > 0f)
        {
            oxygenCount -= Time.deltaTime;
        }
        else if (underwater == false && oxygenCount < 100f)
        {
            oxygenCount += Time.deltaTime * oxygenReplenishRate;
        }
    }

    void PlayerPhysicsHandler()
    {
        if (underwater == true)
        {
            rb.gravityScale = UniversalValues.underwaterGravity;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "WaterBlock")
        {
            underwater = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("WaterBlock"))
        {
            underwater = false;
        }
    }
}
