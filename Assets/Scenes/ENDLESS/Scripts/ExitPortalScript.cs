using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortalScript : MonoBehaviour
{
    GameObject entryPortal;
    GameObject player;
    GameObject centerCell;
    List<GameObject> centerCellSpawnPoints = new List<GameObject>();

    SoundsManagerScript soundsManagerScript;
    RoomTemplates roomTemplates;

    void Start()
    {
        entryPortal = GameObject.Find("EntryPortal");
        player = GameObject.Find("Player");
        centerCell = GameObject.Find("C");
        roomTemplates = GameObject.Find("RoomTemplates").GetComponent<RoomTemplates>();
        soundsManagerScript = GameObject.Find("SoundsManager").GetComponent<SoundsManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("DETECTED PLAYER");
            player.transform.position = entryPortal.transform.position;
            soundsManagerScript.SoundWhirlpool();
            RegenerateWalls();
        }
    }

    void RegenerateWalls()
    {
        foreach (GameObject disposable in GameObject.FindGameObjectsWithTag("EndlessDisposableWall"))
        {
            Destroy(disposable);
            Debug.Log("Destroyed");
        }

        foreach (GameObject trash in GameObject.FindGameObjectsWithTag("EndlessTrash"))
        {
            Destroy(trash);
        }

        foreach (GameObject bubble in GameObject.FindGameObjectsWithTag("EndlessBubble"))
        {
            Destroy(bubble);
        }

        foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            Debug.Log("Reset spawn status");
            spawnPoint.GetComponent<RoomSpawner>().spawned = false;
        }

        foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            spawnPoint.GetComponent<RoomSpawner>().BeginSpawn();
        }

        roomTemplates.waitTime = 1.5f;
        roomTemplates.spawnedExit = false;
        Destroy(this.gameObject);
    }
}
