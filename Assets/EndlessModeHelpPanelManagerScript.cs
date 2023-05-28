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

    public GameObject tutorialHelpOverlayEndless;

    // Start is called before the first frame update
    void Start()
    {
        tutorialImage = GameObject.Find("TutorialImagePicture").GetComponent<Image>();
        tutorialHeaderText = GameObject.Find("TutorialTitleText").GetComponent<TMP_Text>();
        tutorialBodyText = GameObject.Find("TutorialBodyText").GetComponent<TMP_Text>();

        // tutorialCounterText = GameObject.Find("TutorialCounterText").GetComponent<TMP_Text>();

        buttonEndlessModeHelpButton = GameObject.Find("EndlessModeHelpButton").GetComponent<Button>();

        buttonCloseTutorial = GameObject.Find("TutorialCloseButton").GetComponent<Button>();
        
        EndlessModeTutorialPanel = GameObject.Find("TutorialPanelEmpty");

        //updatePanel();
        addButtonListeners();
    }

    void addButtonListeners(){
        buttonCloseTutorial.onClick.AddListener(closePanel);
        buttonEndlessModeHelpButton.onClick.AddListener(openHelpOverlay);
    }

    void openHelpOverlay(){
        helpOverlay.SetActive(true);
    }

     void closePanel(){
        EndlessModeTutorialPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
