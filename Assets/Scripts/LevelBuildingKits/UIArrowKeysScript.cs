using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArrowKeysScript : MonoBehaviour
{
    Image leftArrow, upArrow, rightArrow, downArrow;
    Color gray;
    Color white;

    void Start()
    {
        leftArrow = gameObject.transform.Find("LeftArrow").gameObject.GetComponent<Image>(); ;
        upArrow = gameObject.transform.Find("UpArrow").gameObject.GetComponent<Image>();
        rightArrow = gameObject.transform.Find("RightArrow").gameObject.GetComponent<Image>();
        downArrow = gameObject.transform.Find("DownArrow").gameObject.GetComponent<Image>();
        gray = new Color(160f, 160f, 160f);
        white = new Color(255f, 255f, 255f);
    }

    public void ActivateArrow(string direction)
    {
        switch (direction)
        {
            case "left":
                leftArrow.color = Color.gray;
                break;
            case "up":
                upArrow.color = Color.gray;
                break;
            case "right":
                rightArrow.color = Color.gray;
                break;
            case "down":
                downArrow.color = Color.gray;
                break;
        }
        Debug.Log("Activating arrow: " + direction);
    }

    public void DeactivateArrow(string direction)
    {
        switch (direction)
        {
            case "left":
                leftArrow.color = Color.white;
                break;
            case "up":
                upArrow.color = Color.white;
                break;
            case "right":
                rightArrow.color = Color.white;
                break;
            case "down":
                downArrow.color = Color.white;
                break;
        }

        Debug.Log("Deactivating arrow: " + direction);
    }
}
