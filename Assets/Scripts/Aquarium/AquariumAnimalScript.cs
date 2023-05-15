using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AquariumAnimalScript : MonoBehaviour
{
    public int affectionCount = 0;

    public GameObject directorPf;
    GameObject director;
    GameObject myBounds;

    Rigidbody2D rb;

    AIDestinationSetter aiDestinationSetter;
    AIPath aiPath;

    float xScale;

    Vector2 boundsSize, boundsUL, boundsUR, boundsDL, boundsDR;
    Transform boundsParent;

    float defaultGravity;

    void Start()
    {
        aiDestinationSetter = gameObject.GetComponent<AIDestinationSetter>();
        aiPath = gameObject.GetComponent<AIPath>();

        myBounds = transform.parent.Find("Bounds").gameObject;


        xScale = transform.localScale.x;
        rb = gameObject.GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;

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
        if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
        else if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
        }
    }

    void ChaseBehaviorHandler()
    {
        aiPath.maxSpeed = 1.5f;
        aiPath.maxAcceleration = 3f;
        aiDestinationSetter.target = director.transform;
    }

    IEnumerator FishDirectorHandler()
    {
        director = Instantiate(directorPf, transform.localPosition, transform.rotation, boundsParent);

        float directorRandX = Random.Range(boundsDL.x, boundsUR.x);
        float directorRandY = Random.Range(boundsDL.y, boundsUR.y);

        director.transform.localPosition = new Vector2(directorRandX, directorRandY);
        // director.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(Random.Range(4f, 7f));
        Destroy(director);
        StartCoroutine("FishDirectorHandler");
        yield break;
    }
}
