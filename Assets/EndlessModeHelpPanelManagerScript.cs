using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndlessModeHelpPanelManagerScript : MonoBehaviour
{
    public List<Sprite> tutorialSprites = new List<Sprite>();
    public List<string> tutorialHeader = new List<string>();
    public List<string> tutorialBody = new List<string>();
    //public int index = 0;
    public GameObject helpOverlay;

    Image tutorialImage;
    TMP_Text tutorialHeaderText;
    TMP_Text tutorialBodyText;
    // TMP_Text tutorialCounterText;
    Button buttonCloseTutorial;
    Button buttonEndlessModeHelpButton;
    GameObject EndlessModeTutorialPanel;
    GameObject EndlessTutorialPanel;
    // public GameObject tutorialHelpOverlayEndless;
    bool hideflag = false;

    // Start is called before the first frame update
    void Start()
    {
        tutorialImage = GameObject.Find("TutorialImagePicture").GetComponent<Image>();
        tutorialHeaderText = GameObject.Find("TutorialTitleText").GetComponent<TMP_Text>();
        tutorialBodyText = GameObject.Find("TutorialBodyText").GetComponent<TMP_Text>();

        // tutorialCounterText = GameObject.Find("TutorialCounterText").GetComponent<TMP_Text>();

        buttonEndlessModeHelpButton = GameObject.Find("EndlessModeHelpButton").GetComponent<Button>();

        buttonCloseTutorial = GameObject.Find("TutorialCloseButton").GetComponent<Button>();
        
        EndlessTutorialPanel = GameObject.Find("TutorialPanelEmpty");

        //updatePanel();
        addButtonListeners();
    }

    void addButtonListeners(){
        buttonCloseTutorial.onClick.AddListener(closePanel);
        buttonEndlessModeHelpButton.onClick.AddListener(openHelpOverlay);
    }

    void openHelpOverlay(){
        Debug.Log("Tutorial Panel is triggering");
        EndlessTutorialPanel.SetActive(true);
    }

     void closePanel(){
        // EndlessModeTutorialPanel.SetActive(false);
        EndlessTutorialPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if (hideflag == false)
        {
            EndlessTutorialPanel.SetActive(false);
           // descAreaRealLifeImage.SetActive(false);
            hideflag = true;
        }
    }
}
