using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    NotificationsManager notificationsManager;

    UIManagerScript uiManagerScript;
    CheckpointManagerScript checkpointManagerScript;
    SoundsManagerScript soundsManagerScript;
    SlidingNotificationAnimationScript notificationAnimationScript;
    GameObject playerObj;

    public int rawLevelValue = 0;
    public int zoneVal;
    public int levelVal;

    [Tooltip("Gamemode 0 - exploration mode; Gamemode 1 - restoration mode")]
    public int gameMode = 0;
    [Tooltip("0 = animals saved type, 1 = timer type, 2 = quiz type")]
    public int endGameType = 1;
    public bool inTestingMode = true;

    public int starsThisLevel = 0;
    public int bestStars;

    public int trashCount = 0;
    public int animalsSaved = 0;
    public int animalsMet = 0;
    public int currentCheckpoint = 0;
    public int trashbagStackCount = 0;

    public int timeSpentSecs = 0;

    public bool inStackingState = false;
    public bool isGameActive = true;

    public bool activateReturnPoint = false;

    public int userScore = 0;

    public float timeSpent = 0;
    public int bestTimeSpent;


    //FOR ANIMATION//
    public Animator animateNotificationBar;

    public GameObject AchievementUnlocked;
    public SlidingNotificationAnimationScript slidingNotificationAnimationScript;

    GameObject startPoint, finishPoint, returnPoint;

    [Tooltip("[1] = one star timer goal, [2] = two star timer goal, [3] = three star timer goal // CONVERT TO SECONDS")]
    public int[] timeGoals = new int[4] { 0, 0, 0, 0 };

    void Start()
    {
        soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();
        UnpackData();
        ComputeZoneLevel();

        notificationsManager = GameObject.Find("NotificationsManager").GetComponent<NotificationsManager>();

        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        checkpointManagerScript = GameObject.Find("CheckpointManager").GetComponent<CheckpointManagerScript>();

        // slidingNotificationAnimationScript = GameObject.Find("AchievementUnlocked").GetComponent<SlidingNotificationAnimationScript>();

        // soundsManagerScript = GameObject.Find("SoundsManager").
        // GetComponent<SoundsManagerScript>();

        //find animator object
        //animateNotificationBar = GameObject.Find("AchievementUnlocked").GetComponent<Animator>();


        playerObj = GameObject.Find("Player");

        startPoint = GameObject.Find("StartPoint");
        finishPoint = GameObject.Find("FinishPoint");
        returnPoint = GameObject.Find("ReturnPoint");

        StartGame();
        Time.timeScale = 1;

        //NOTIFICATION ANIMATION
        // startPosition = transform.position;
        // targetPosition = startPosition - new Vector3(0f, slideDistance, 0f);

        // Start the sliding animation
        // StartCoroutine(notificationAnimation());
        //NOTIFICATION ANIMATION
    }

    void ComputeZoneLevel()
    {
        switch (rawLevelValue)
        {
            case 0:
                zoneVal = 0;
                levelVal = 0;
                break;
            case 1:
                zoneVal = 0;
                levelVal = 1;
                break;
            case 2:
                zoneVal = 1;
                levelVal = 0;
                break;
            case 3:
                zoneVal = 1;
                levelVal = 1;
                break;
            case 4:
                zoneVal = 2;
                levelVal = 0;
                break;
            case 5:
                zoneVal = 2;
                levelVal = 1;
                break;
        }
        Debug.Log("ZONEVAL: " + zoneVal + " LEVELVAL: " + levelVal);
    }

    void Update()
    {
        if (isGameActive == true)
        {
            timeSpent += Time.deltaTime;
            timeSpentSecs = Convert.ToInt32(timeSpent);
        }
    }

    void StartGame()
    {
        // if (inTestingMode == false)
        // {
        //     playerObj.transform.position = checkpointManagerScript.startPoint.transform.position;
        // }
    }

    public void ToggleGamePause(bool isPaused)
    {
        if (isPaused == true)
        {
            Time.timeScale = 0;
            isGameActive = false;
        }
        else
        {
            Time.timeScale = 1;
            isGameActive = true;
        }
    }

    public void LevelCompletedQuiz(int quizScore = 0)
    {
        Time.timeScale = 0;
        userScore = quizScore;
        uiManagerScript.DisplayLevelCompletePanel(userScore);
        starsThisLevel = userScore;
        CompareBests();
        SceneDataHandler.FinishedLevel(zoneVal, levelVal);

        //notification slider
        // notificationAnimationScript.playNotificationAnimation();
    }

    public void CompareBests()
    {
        Debug.Log("Comparing bests");
        if (starsThisLevel > bestStars)
        {
            Debug.Log("Set new star record");
            bestStars = starsThisLevel;
            SceneDataHandler.activeUser.levelStars[rawLevelValue] = bestStars;
            Debug.Log("New score: " + SceneDataHandler.activeUser.levelStars[rawLevelValue]);
        }

        if (timeSpent < bestTimeSpent)
        {
            Debug.Log("Set new time record");
            bestTimeSpent = Convert.ToInt32(timeSpent);
            SceneDataHandler.activeUser.levelBestTime[rawLevelValue] = bestTimeSpent;
            Debug.Log("New record: " + SceneDataHandler.activeUser.levelBestTime[rawLevelValue]);
        }

        soundsManagerScript.SoundVictory();
        notificationsManager.OceanTamerAchievement();
        // notificationAnimationScript.StartAnimation();
        //slidingNotificationAnimationScript.playNotificationAnimation();
    }



    public void UnpackData()
    {
        bestStars = SceneDataHandler.activeUser.levelStars[rawLevelValue];
        bestTimeSpent = SceneDataHandler.activeUser.levelBestTime[rawLevelValue];
        Debug.Log("Best stars for this level: " + bestStars + ", best time spent for this level: " + bestTimeSpent);
    }



    // //SOUNDS
    // public void playGameOverSound()
    // {
    //     soundsManagerScript.PlaySound("GameoverSound");
    // }

    // public void playVictorySound()
    // {
    //     soundsManagerScript.PlaySound("Sound");
    // }


}
