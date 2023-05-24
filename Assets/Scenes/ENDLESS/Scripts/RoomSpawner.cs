using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 - need bottom door
    // 2 - need top door
    // 3 - need left door
    // 4 - need right door

    RoomTemplates templates;
    int rand;
    public bool spawned = false;

    void Start()
    {
        templates = GameObject.Find("RoomTemplates").GetComponent<RoomTemplates>();
        BeginSpawn();
    }

    public void BeginSpawn()
    {
        Invoke("Spawn", 0.1f);
    }

    public void Spawn()
    {
        Debug.Log("Spawning");
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                // need to spawn a room with bottom door
                Debug.Log("bottomRooms: " + templates.leftRooms.Length);
                rand = Random.Range(0, templates.bottomRooms.Length - 1);
                Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                // need to spawn a room with top door
                Debug.Log("topRooms: " + templates.leftRooms.Length);
                rand = Random.Range(0, templates.topRooms.Length - 1);
                Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                // need to spawn a room with left door
                Debug.Log("leftRooms: " + templates.leftRooms.Length);
                rand = Random.Range(0, templates.leftRooms.Length - 1);
                Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                // need to spawn a room with rightdoor
                Debug.Log("rightRooms: " + templates.leftRooms.Length);
                rand = Random.Range(0, templates.rightRooms.Length - 1);
                Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
            }
            Instantiate(templates.RandomizeContentCell(), transform.position, Quaternion.identity);
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SpawnPoint")
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                // Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                GameObject.CreatePrimitive(PrimitiveType.Cube);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}