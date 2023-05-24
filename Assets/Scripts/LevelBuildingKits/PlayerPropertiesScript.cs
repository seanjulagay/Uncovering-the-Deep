using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPropertiesScript : MonoBehaviour
{
    public UIManagerScript uiManagerScript;
    public GameObject uiOxygenBar;

    Rigidbody2D rb;

    public float oxygenCount = 99f;
    public float playerScore;
    public bool underwater = false;

    float oxygenReplenishRate = 5f;

    void Start()
    {
        try
        {
            uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
            uiOxygenBar = GameObject.Find("OxygenBar");
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        // Debug.Log("Loaded PlayeRProps");
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
        else if (oxygenCount <= 0f)
        {
            uiManagerScript.DisplayGameOverPanel();
        }

        try
        {
            uiOxygenBar.GetComponent<UIProgressBarScript>().current = (int)oxygenCount;
        }
        catch (Exception e)
        {
            Debug.Log(e);
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
