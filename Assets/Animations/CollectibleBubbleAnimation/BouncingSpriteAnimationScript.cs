using UnityEngine;
using Pathfinding;


public class BouncingSpriteAnimationScript : MonoBehaviour
{
    // Adjust this to change the speed of the animation
    public float speed = 2f;

    // Adjust this to change the height of the bounce
    public float height = 1f;

    public bool enableBounce = true;

    private float startY; // The initial Y position of the sprite

    private void Start()
    {
        startY = transform.position.y; // Store the initial Y position of the sprite
    }

    private void Update()
    {
        if (enableBounce == true)
        {
            // Calculate the new Y position using a sine wave
            float newY = startY + Mathf.Sin(Time.time * speed) * height;

            // Update the sprite's position
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}
