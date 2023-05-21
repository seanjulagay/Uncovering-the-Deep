using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnerScript : MonoBehaviour
{
    public int openingDirection;
    // 1 -> need bottom door
    // 2 -> need top door
    // 3 -> need left door
    // 4 -> need right door

    private RoomTemplatesScript templates;
    private int rand;
    private bool spawned = false;

    void Start(){
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplatesScript>();
        Invoke("Spawn", 5f);
    }

    void Spawn()
    {
        if (spawned == false){
            if (openingDirection == 1){
            //need to spawn room with BOTTOM DOOR
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }else if (openingDirection == 2){
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                //need to spawn room with TOP DOOR
            }else if (openingDirection == 3){
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                //need to spawn room with LEFT DOOR
            }else if (openingDirection == 4){
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                //need to spawn room with RIGHT DOOR
            }
            spawned = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpawnPoint")){
            Destroy(gameObject);
        }
    }
}
