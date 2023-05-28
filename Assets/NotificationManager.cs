using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System.Collections;



public class NotificationManager : MonoBehaviour
{
    public GameObject notificationBar; // Reference to the notification bar 
    public AudioClip clip;
    public AudioSource audio;
    //public List <string> queue;
    public GameObject notificationPanel;
    WaitForSeconds waitTime;
    WaitForSeconds notificationTime;
    bool isNotificationPaneActive;

    private void Start()
    {
        notificationPanel = GameObject.Find("NotificationPanel");

        notificationTime = new WaitForSeconds(5.0f);
        waitTime = new WaitForSeconds(1.0f);

        audio = GetComponent<AudioSource>();
        audio.clip = clip;
    }

    void Update(){
        if (notificationPanel == !isNotificationPaneActive){
            //Play our notification
            StartCoroutine(PlayNotification());
        }

    }

    //public void

    IEnumerator PlayNotification(){
            notificationPanel.SetActive(true);
            isNotificationPaneActive = true;

            yield return notificationTime;

            notificationPanel.SetActive(false);
            isNotificationPaneActive = false;

            yield return waitTime;
        }

    
}
