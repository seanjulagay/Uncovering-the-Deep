using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChasingAnimalScript : MonoBehaviour
{
    AIPath aiPath;
    float xScale;

    void Start()
    {
        aiPath = gameObject.GetComponent<AIPath>();
        xScale = transform.localScale.x;
    }

    void Update()
    {
        OrientationHandler();
    }

    void OrientationHandler()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
        else if (aiPath.desiredVelocity.y <= 0.01f)
        {
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
        }
    }

}
