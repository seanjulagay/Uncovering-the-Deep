using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsManagerScript : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "WaterBlock")
        {
            rb.gravityScale = UniversalValues.underwaterGravity;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "WaterBlock")
        {
            rb.gravityScale = 1f;
        }
    }
}
