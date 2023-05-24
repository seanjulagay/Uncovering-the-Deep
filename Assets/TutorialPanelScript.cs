using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialPanelScript : MonoBehaviour
{
    public List<Sprite> tutorialSprites = new List<Sprite>();
    public List<string> tutorialHeader = new List<string>();
    public List<string> tutorialBody = new List<string>();
    public int index = 0;

    Image tutorialImage;
    TMP_Text tutorialHeaderText;
    TMP_Text tutorialBodyText;
    TMP_Text tutorialCounterText;

    Button buttonNextTutorial;
    Button buttonPrevTutorial;
    Button buttonCloseTutorial;
    GameObject TutorialPanel;


    // Start is called before the first frame update
    void Start()
    {
        tutorialImage = GameObject.Find("TutorialImagePicture").GetComponent<Image>();
        tutorialHeaderText = GameObject.Find("TutorialTitleText").GetComponent<TMP_Text>();
        tutorialBodyText = GameObject.Find("TutorialBodyText").GetComponent<TMP_Text>();

        tutorialCounterText = GameObject.Find("TutorialCounterText").GetComponent<TMP_Text>();

        buttonCloseTutorial = GameObject.Find("TutorialCloseButton").GetComponent<Button>();
        buttonNextTutorial = GameObject.Find("TutorialNextButton").GetComponent<Button>();
        buttonPrevTutorial = GameObject.Find("TutorialBackButton").GetComponent<Button>();

        TutorialPanel = GameObject.Find("TutorialPanelEmpty");

        updatePanel();
        addButtonListeners();
    }

    void updatePanel(){
        tutorialImage.sprite = tutorialSprites[index];
        tutorialHeaderText.text = tutorialHeader[index];
        tutorialBodyText.text = "<br>" + tutorialBody[index];
        tutorialCounterText.text = (index+1) + "/" + tutorialSprites.Count;
    }

    void nextPanel(){
        if (index<(tutorialSprites.Count-1)){
            index++;
            updatePanel();
        }
    }

    void prevPanel(){
        if (index>0){
            index--;
            updatePanel();
        }
    }

    void addButtonListeners(){
        buttonNextTutorial.onClick.AddListener(nextPanel);
        buttonPrevTutorial.onClick.AddListener(prevPanel);
        buttonCloseTutorial.onClick.AddListener(closePanel);
    }

    void closePanel(){
        TutorialPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
