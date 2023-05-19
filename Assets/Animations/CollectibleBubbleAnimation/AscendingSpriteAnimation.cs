using UnityEngine;

public class AscendingSpriteAnimation : MonoBehaviour
{
    public float ascendingDuration = 1f;   // Duration of the ascending animation
    public float respawnDelay = 1f;        // Delay before respawning to the original position
    public float speed = 1f;                // Speed factor for the ascending animation

    private Vector3 originalPosition;      // The original position of the sprite
    private float timer;                    // Timer to track the animation progress
    private bool isAnimating;               // Flag to check if the animation is currently in progress

    private void Start()
    {
        originalPosition = transform.position;
        StartAnimation();
    }

    private void Update()
    {
        if (isAnimating)
        {
            // Animation is in progress
            timer += Time.deltaTime;

            // Calculate the new position based on the ascending animation
            float t = timer / ascendingDuration;
            Vector3 newPosition = originalPosition + Vector3.up * (t / ascendingDuration) * speed;

            // Update the sprite's position
            transform.position = newPosition;

            if (timer >= ascendingDuration)
            {
                // Ascending animation completed
                timer = 0f;
                isAnimating = false;

                // Start the delay before respawning
                Invoke("Respawn", respawnDelay);
            }
        }
    }

    private void Respawn()
    {
        // Reset the sprite's position to the original position
        transform.position = originalPosition;

        // Start the ascending animation again
        isAnimating = true;
    }

    private void StartAnimation()
    {
        // Start the ascending animation
        isAnimating = true;
    }
}
