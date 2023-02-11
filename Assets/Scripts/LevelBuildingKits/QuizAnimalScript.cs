using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class QuizAnimalScript : MonoBehaviour
{
    public string q1 = "question1";
    public string[] q1options = new string[3] { "option1", "option2", "option3" };
    public int q1answer = 0;

    public string q2 = "question2";
    public string[] q2options = new string[3] { "option1", "option2", "option3" };
    public int q2answer = 0;

    public string q3 = "question3";
    public string[] q3options = new string[3] { "option1", "option2", "option3" };
    public int q3answer = 0;

    List<string> compiledQuestions;
    List<string[]> compiledOptions;
    List<int> compiledAnswers;
    List<int> userAnswers = new List<int>();

    int activeQuestion = -1;

    QuizManagerScript quizManagerScript;

    GameObject connectedQuizPanel;
    Button nextButton;
    Button backButton;
    Button leaveButton;

    ToggleGroup toggleGroup;

    bool firstOpen = true;

    // ================ TODO: ADD LISTENER TO NEXT AND BACK BUTTONS PROGRAMMATICALLY

    void Start()
    {
        quizManagerScript = GameObject.Find("QuizManager").GetComponent<QuizManagerScript>();
        connectedQuizPanel = Instantiate(quizManagerScript.quizPanelPf, new Vector3(0, 0, 0), transform.rotation, GameObject.Find("QuizPanels").transform);
        connectedQuizPanel.GetComponent<RectTransform>().localPosition = Vector3.zero;
        connectedQuizPanel.SetActive(false);
        toggleGroup = connectedQuizPanel.transform.Find("QuestionRadioButtons").GetComponent<ToggleGroup>();
        nextButton = connectedQuizPanel.transform.Find("QuizNextButton").gameObject.GetComponent<Button>();
        nextButton.onClick.AddListener(NextQuestion);
        leaveButton = connectedQuizPanel.transform.Find("QuizLeaveButton").gameObject.GetComponent<Button>();
        leaveButton.onClick.AddListener(CloseQuizPanel);

        compiledQuestions = new List<string>() { q1, q2, q3 };
        compiledOptions = new List<string[]>() { q1options, q2options, q3options };
        compiledAnswers = new List<int>() { q1answer, q2answer, q3answer };
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTrigger")
        {
            Debug.Log("HELLO PLAYER");
            OpenQuizPanel();
            if (firstOpen == true)
            {
                firstOpen = false;
                activeQuestion++;
                UpdateQuizPanel();
            }
            else
            {
                UpdateQuizPanel();
            }
        }
    }

    void UpdateQuizPanel()
    {
        GameObject questionPrompt = connectedQuizPanel.transform.Find("QuestionPromptText").gameObject;

        GameObject option1 = connectedQuizPanel.transform.Find("QuestionRadioButtons/Option1/Label").gameObject;
        GameObject option2 = connectedQuizPanel.transform.Find("QuestionRadioButtons/Option2/Label").gameObject;
        GameObject option3 = connectedQuizPanel.transform.Find("QuestionRadioButtons/Option3/Label").gameObject;

        questionPrompt.GetComponent<TMP_Text>().text = (activeQuestion + 1) + ". " + compiledQuestions[activeQuestion];
        option1.GetComponent<Text>().text = compiledOptions[activeQuestion][0];
        option2.GetComponent<Text>().text = compiledOptions[activeQuestion][1];
        option3.GetComponent<Text>().text = compiledOptions[activeQuestion][2];
    }

    void OpenQuizPanel()
    {
        Time.timeScale = 0;
        connectedQuizPanel.SetActive(true);
    }

    void CloseQuizPanel()
    {
        Time.timeScale = 1;
        connectedQuizPanel.SetActive(false);
    }

    void NextQuestion()
    {
        Debug.Log("Hello World!");
        GameObject activeToggle = toggleGroup.ActiveToggles().FirstOrDefault().gameObject;

        for (int i = 0; i < 3; i++)
        {
            if (activeToggle.name == "Option" + (i + 1))
            {
                userAnswers.Add(i);
                activeQuestion++;
                if (activeQuestion < 3)
                {
                    UpdateQuizPanel();
                }
                else
                {
                    ShowQuizResults();
                }
                // Debug.Log($"User selected option {i + 1}, adding {i} into userAnswers");
                break;
            }
        }
    }

    void ShowQuizResults()
    {
        int userScore = 0;

        for (int i = 0; i < compiledAnswers.Count; i++)
        {
            if (userAnswers[i] == compiledAnswers[i])
            {
                userScore++;
            }
        }

        Debug.Log($"User scored {userScore}");
    }
}
