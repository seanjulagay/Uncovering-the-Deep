using UnityEngine;

public class SlidingNotificationAnimationScript : MonoBehaviour
{
    public float slideDistance = 100f; // Distance to slide down
    public float slideDuration = 1f; // Duration of the slide animation
    public float retractDelay = 2f; // Delay before retracting the bar
    public float retractDuration = 1f; // Duration of the retract animation

    private Vector3 startPosition;
    private Vector3 targetPosition;

    public Animation animationComponent;
    public string PopUp_Animation;
    public Animator animateNotificationBar;


    void Start()
    {
        animateNotificationBar = gameObject.GetComponent<Animator>();

        //animationComponent = GetComponent<Animation>();
    }

    public void playNotificationAnimation(){
        //animationComponent.Play(PopUp_Animation);
        
        animateNotificationBar.SetTrigger("NotificationPopUpTrigger");
    }

    // IEnumerator TriggerSlideAnimation()
    // {
    //     // Wait for the level completion event
    //     yield return new WaitForSeconds(2f); // Adjust the delay time as needed

    //     // Trigger the sliding animation
    //     animateNotificationBar.SetTrigger("SlideTrigger");
    // }


}
