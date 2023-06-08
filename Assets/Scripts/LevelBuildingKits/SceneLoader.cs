using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    MenuManagerScript menuManagerScript;

    void Awake()
    {
        menuManagerScript = GameObject.Find("MenuManager").GetComponent<MenuManagerScript>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneDataHandler.showMapFlag == true)
        {
            ShowMap();
            SceneDataHandler.showMapFlag = false;
        }
    }

    void ShowMap()
    {
        Debug.Log("Called ShowMap() from SceneLoader");
        menuManagerScript.OpenZoneOverlay();
    }
}
