using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReturnPointScript : MonoBehaviour
{
    UIManagerScript uiManagerScript;
    GameManagerScript gameManagerScript;

    GameObject levelCompletePanel;
    Image levelCompleteStarsImg;

    TMP_Text levelCompleteHeaderText;
    Sprite[] levelCompleteStarsArr;

    bool displayDetails = false;

    void Start()
    {
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        levelCompletePanel = GameObject.Find("LevelCompletePanel");
        levelCompleteStarsImg = GameObject.Find("LevelCompleteStars").GetComponent<Image>();

        levelCompleteHeaderText = GameObject.Find("LevelCompleteHeaderText").GetComponent<TMP_Text>();

        levelCompleteStarsArr = new Sprite[4] { uiManagerScript.levelCompleteStars0, uiManagerScript.levelCompleteStars1, uiManagerScript.levelCompleteStars2, uiManagerScript.levelCompleteStars3 };
    }

    void Update()
    {
        if (displayDetails == true)
        {
            Debug.Log("gameManagerScript.timeSpentSecs: " + gameManagerScript.timeSpentSecs + " gameManagerScript.starsThisLevel: " + gameManagerScript.starsThisLevel);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTrigger" && gameManagerScript.activateReturnPoint == true)
        {
            if (gameManagerScript.endGameType == 0) // animals saved type
            {
                levelCompleteStarsImg.sprite = levelCompleteStarsArr[3];
            }
            else if (gameManagerScript.endGameType == 1) // timer type
            {
                if (gameManagerScript.timeSpentSecs <= gameManagerScript.timeGoals[3])
                {
                    gameManagerScript.starsThisLevel = 3;
                    levelCompleteStarsImg.sprite = levelCompleteStarsArr[3];
                }
                else if (gameManagerScript.timeSpentSecs <= gameManagerScript.timeGoals[2])
                {
                    gameManagerScript.starsThisLevel = 2;
                    levelCompleteStarsImg.sprite = levelCompleteStarsArr[2];
                }
                else if (gameManagerScript.timeSpentSecs <= gameManagerScript.timeGoals[1])
                {
                    gameManagerScript.starsThisLevel = 1;
                    levelCompleteStarsImg.sprite = levelCompleteStarsArr[1];
                }
                else
                {
                    gameManagerScript.starsThisLevel = 0;
                    levelCompleteStarsImg.sprite = levelCompleteStarsArr[0];
                }

                displayDetails = true;
            }
            gameManagerScript.CompareBests();
            SceneDataHandler.FinishedLevel(gameManagerScript.zoneVal, gameManagerScript.levelVal);
            levelCompleteHeaderText.text = "Level Complete!";
            levelCompletePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
