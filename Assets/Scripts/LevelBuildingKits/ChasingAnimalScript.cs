using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChasingAnimalScript : MonoBehaviour
{
    public float maxSpeed = 3f;
    public float maxAcceleration = 5f;
    public GameObject directorPf;
    public GameObject playerObj;
    GameObject director;

    AIDestinationSetter aiDestinationSetter;

    Rigidbody2D rb;
    AIPath aiPath;
    float xScale;
    public bool isChasing = false;
    public bool inBounds = false;

    Vector2 boundsSize, boundsUL, boundsUR, boundsDL, boundsDR;
    Transform boundsParent;

    float defaultGravity;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");

        aiDestinationSetter = gameObject.GetComponent<AIDestinationSetter>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        aiPath = gameObject.GetComponent<AIPath>();
        aiPath.maxSpeed = maxSpeed;
        aiPath.maxAcceleration = maxAcceleration;
        xScale = transform.localScale.x; // stored one time in variable because using explicit localScale.x causes infinite flipping for orientation handler
        defaultGravity = rb.gravityScale;

        // ESTABLISH CORNERS FOR BOUNDS
        boundsSize = transform.parent.Find("Bounds").localScale;
        boundsUL = new Vector2(-(boundsSize.x / 2), boundsSize.y / 2);
        boundsUR = new Vector2(boundsSize.x / 2, boundsSize.y / 2);
        boundsDL = new Vector2(-(boundsSize.x / 2), -(boundsSize.y / 2));
        boundsDR = new Vector2(boundsSize.x / 2, -(boundsSize.y / 2));

        boundsParent = transform.parent;
        StartCoroutine("FishDirectorHandler");
    }

    void Update()
    {
        OrientationHandler();
        ChaseBehaviorHandler();
    }

    void OrientationHandler()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
        else if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
        }
    }

    public void ChaseBehaviorHandler()
    {
        if (isChasing == true)
        {
            aiPath.maxSpeed = maxSpeed;
            aiPath.maxAcceleration = maxAcceleration;
            aiDestinationSetter.target = playerObj.transform;
        }
        else
        {
            aiPath.maxSpeed = 1.5f;
            aiPath.maxAcceleration = 3f;
            aiDestinationSetter.target = director.transform;
        }
    }

    IEnumerator FishDirectorHandler()
    {
        director = Instantiate(directorPf, transform.localPosition, transform.rotation, boundsParent);

        float directorRandX = Random.Range(boundsDL.x, boundsUR.x);
        float directorRandY = Random.Range(boundsDL.y, boundsUR.y);

        director.transform.localPosition = new Vector2(directorRandX, directorRandY);
        director.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(2f);
        Destroy(director);
        StartCoroutine("FishDirectorHandler");
        yield break;
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "ChaseBounds")
    //     {
    //         inBounds = true;
    //     }
    // }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "ChaseBounds")
    //     {
    //         inBounds = false;
    //     }
    // }

    // IEnumerator GenerateRandomVelocity()
    // {
    //     while (isChasing == false)
    //     {
    //         Debug.Log("GENERATED RANDOM VELOCITY");
    //         int xvel = Random.Range(-2, 2);
    //         int yvel = Random.Range(-2, 2);
    //         int secs = Random.Range(2, 4);

    //         if (xvel == 0)
    //         {
    //             xvel++;
    //         }

    //         if (yvel == 0)
    //         {
    //             yvel++;
    //         }

    //         xVelRand = xvel;
    //         yVelRand = yvel;
    //         // Debug.Log("xVelRand: " + xVelRand + " yVelRand: " + yVelRand);

    //         rb.velocity = new Vector2(xVelRand, yVelRand);
    //         Debug.Log("WAITED FOR: " + secs);
    //         yield return new WaitForSeconds(secs);
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "ChaseBounds")
    //     {
    //         inBounds = true;
    //         // StartCoroutine(GenerateRandomVelocity());
    //     }
    // }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "ChaseBounds")
    //     {
    //         // StopCoroutine(GenerateRandomVelocity());
    //         Debug.Log("STOPPED COROUTINE");
    //         inBounds = false;
    //         // if (gameObject.transform.localPosition.x > other.gameObject.transform.localPosition.x || gameObject.transform.localPosition.x < other.gameObject.transform.localPosition.y)
    //         // {
    //         //     rb.velocity = new Vector2(-xVelRand, rb.velocity.y);
    //         // }

    //         // if (gameObject.transform.localPosition.y > other.gameObject.transform.localPosition.y || gameObject.transform.localPosition.y < other.gameObject.transform.localPosition.y)
    //         // {
    //         //     rb.velocity = new Vector2(rb.velocity.x, -yVelRand);
    //         // }

    //         if (rb.velocity.x > 0 || rb.velocity.x < 0)
    //         {
    //             rb.velocity = new Vector2(-xVelRand, rb.velocity.y);
    //         }

    //         if (rb.velocity.y > 0 || rb.velocity.y < 0)
    //         {
    //             rb.velocity = new Vector2(rb.velocity.x, -yVelRand);
    //         }
    //     }
    // }
}
