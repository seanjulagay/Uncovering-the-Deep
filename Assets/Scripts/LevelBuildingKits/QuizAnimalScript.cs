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

    public List<int> userAnswers = new List<int>(new int[] { 0, 0, 0 });
    List<string> compiledQuestions;
    List<string[]> compiledOptions;
    List<int> compiledAnswers;

    public int activeQuestion;

    GameManagerScript gameManagerScript;
    QuizManagerScript quizManagerScript;

    GameObject quizPanel;
    public Button nextButton;
    public Button backButton;
    public Button leaveButton;

    ToggleGroup toggleGroup;
    List<Toggle> toggle = new List<Toggle>(new Toggle[3]);

    bool addListenersFlag = false;

    // ================ TODO: ADD LISTENER TO NEXT AND BACK BUTTONS PROGRAMMATICALLY

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        quizManagerScript = GameObject.Find("QuizManager").GetComponent<QuizManagerScript>();

        // quizPanel = Instantiate(quizManagerScript.quizPanelPf, new Vector3(0, 0, 0), transform.rotation, GameObject.Find("QuizPanels").transform);

        quizPanel = GameObject.Find("QuizPanel");
        quizPanel.GetComponent<RectTransform>().localPosition = Vector3.zero;
        quizPanel.SetActive(false);
        toggleGroup = quizPanel.transform.Find("QuestionRadioButtons").GetComponent<ToggleGroup>();
        toggle[0] = toggleGroup.transform.Find("Option1").gameObject.GetComponent<Toggle>();
        toggle[1] = toggleGroup.transform.Find("Option2").gameObject.GetComponent<Toggle>();
        toggle[2] = toggleGroup.transform.Find("Option3").gameObject.GetComponent<Toggle>();
        nextButton = quizPanel.transform.Find("QuizNextButton").gameObject.GetComponent<Button>();
        // nextButton.onClick.AddListener(NextQuestion);
        backButton = quizPanel.transform.Find("QuizBackButton").gameObject.GetComponent<Button>();
        // backButton.onClick.AddListener(PreviousQuestion);
        leaveButton = quizPanel.transform.Find("QuizLeaveButton").gameObject.GetComponent<Button>();
        // leaveButton.onClick.AddListener(CloseQuizPanel);

        compiledQuestions = new List<string>() { q1, q2, q3 };
        compiledOptions = new List<string[]>() { q1options, q2options, q3options };
        compiledAnswers = new List<int>() { q1answer, q2answer, q3answer };

        nextButton.onClick.AddListener(NextQuestion);
        backButton.onClick.AddListener(PreviousQuestion);
        leaveButton.onClick.AddListener(CloseQuizPanel);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTrigger")
        {
            Debug.Log("HELLO PLAYER");
            OpenQuizPanel();
            activeQuestion = 0;
            UpdateQuizPanel();
        }
    }

    void UpdateQuizPanel()
    {
        Debug.Log($"CALLED FROM UPDATEQUIZPANEL, activeQuestion is {activeQuestion}");
        GameObject questionPrompt = quizPanel.transform.Find("QuestionPromptText").gameObject;

        GameObject option1 = quizPanel.transform.Find("QuestionRadioButtons/Option1/Label").gameObject;
        GameObject option2 = quizPanel.transform.Find("QuestionRadioButtons/Option2/Label").gameObject;
        GameObject option3 = quizPanel.transform.Find("QuestionRadioButtons/Option3/Label").gameObject;

        questionPrompt.GetComponent<TMP_Text>().text = (activeQuestion + 1) + ". " + compiledQuestions[activeQuestion];
        option1.GetComponent<Text>().text = compiledOptions[activeQuestion][0];
        option2.GetComponent<Text>().text = compiledOptions[activeQuestion][1];
        option3.GetComponent<Text>().text = compiledOptions[activeQuestion][2];

        for (int i = 0; i < 3; i++)
        {
            toggle[i].isOn = false;
        }

        for (int i = 0; i < 3; i++)
        {
            if (userAnswers[activeQuestion] == i)
            {
                toggle[i].isOn = true;
                break;
            }
        }
    }

    void OpenQuizPanel()
    {
        Time.timeScale = 0;
        quizPanel.SetActive(true);
    }

    void CloseQuizPanel()
    {
        GameObject activeToggle = toggleGroup.ActiveToggles().FirstOrDefault().gameObject;

        for (int i = 0; i < 3; i++)
        {
            if (activeToggle.name == "Option" + (i + 1))
            {
                userAnswers[activeQuestion] = i;
            }
        }
        Debug.Log("Clicked CloseQuizPanel");
        Time.timeScale = 1;
        quizPanel.SetActive(false);
    }

    void NextQuestion()
    {
        GameObject activeToggle = toggleGroup.ActiveToggles().FirstOrDefault().gameObject;

        for (int i = 0; i < 3; i++)
        {
            if (activeToggle.name == "Option" + (i + 1))
            {
                if (activeQuestion < 2)
                {
                    userAnswers[activeQuestion] = i;
                    activeQuestion++;
                    UpdateQuizPanel();
                }
                else
                {
                    userAnswers[activeQuestion] = i;
                    ShowQuizResults();
                }
                Debug.Log($"WENT FORWARD, active question is {activeQuestion}");
                // Debug.Log($"User selected option {i + 1}, adding {i} into userAnswers");
                break;
            }
        }
    }

    void PreviousQuestion()
    {
        GameObject activeToggle = toggleGroup.ActiveToggles().FirstOrDefault().gameObject;

        for (int i = 0; i < 3; i++)
        {
            if (activeToggle.name == "Option" + (i + 1))
            {
                if (activeQuestion > 0)
                {
                    userAnswers[activeQuestion] = i;
                    activeQuestion--;
                    UpdateQuizPanel();
                }
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

        quizPanel.SetActive(false);
        gameManagerScript.LevelCompletedQuiz(userScore);
    }
}

/*

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

    public List<int> userAnswers = new List<int>(new int[] { 0, 0, 0 });
    List<string> compiledQuestions;
    List<string[]> compiledOptions;
    List<int> compiledAnswers;

    public int activeQuestion;

    GameManagerScript gameManagerScript;
    QuizManagerScript quizManagerScript;

    GameObject quizPanel;
    public Button nextButton;
    public Button backButton;
    public Button leaveButton;

    ToggleGroup toggleGroup;
    List<Toggle> toggle = new List<Toggle>(new Toggle[3]);

    bool addListenersFlag = false;

    // ================ TODO: ADD LISTENER TO NEXT AND BACK BUTTONS PROGRAMMATICALLY

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        quizManagerScript = GameObject.Find("QuizManager").GetComponent<QuizManagerScript>();
        quizPanel = Instantiate(quizManagerScript.quizPanelPf, new Vector3(0, 0, 0), transform.rotation, GameObject.Find("QuizPanels").transform);
        quizPanel.GetComponent<RectTransform>().localPosition = Vector3.zero;
        quizPanel.SetActive(false);
        toggleGroup = quizPanel.transform.Find("QuestionRadioButtons").GetComponent<ToggleGroup>();
        toggle[0] = toggleGroup.transform.Find("Option1").gameObject.GetComponent<Toggle>();
        toggle[1] = toggleGroup.transform.Find("Option2").gameObject.GetComponent<Toggle>();
        toggle[2] = toggleGroup.transform.Find("Option3").gameObject.GetComponent<Toggle>();
        nextButton = quizPanel.transform.Find("QuizNextButton").gameObject.GetComponent<Button>();
        // nextButton.onClick.AddListener(NextQuestion);
        backButton = quizPanel.transform.Find("QuizBackButton").gameObject.GetComponent<Button>();
        // backButton.onClick.AddListener(PreviousQuestion);
        leaveButton = quizPanel.transform.Find("QuizLeaveButton").gameObject.GetComponent<Button>();
        // leaveButton.onClick.AddListener(CloseQuizPanel);

        compiledQuestions = new List<string>() { q1, q2, q3 };
        compiledOptions = new List<string[]>() { q1options, q2options, q3options };
        compiledAnswers = new List<int>() { q1answer, q2answer, q3answer };
    }

    void AddListeners()
    {
        nextButton.onClick.AddListener(NextQuestion);
        backButton.onClick.AddListener(PreviousQuestion);
        leaveButton.onClick.AddListener(CloseQuizPanel);
        Debug.Log("next: " + nextButton.onClick.GetPersistentEventCount());
        Debug.Log("back: " + backButton.onClick.GetPersistentEventCount());
        Debug.Log("leave: " + leaveButton.onClick.GetPersistentEventCount());
    }

    void Update()
    {
        if (addListenersFlag == false)
        {
            AddListeners();
            addListenersFlag = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTrigger")
        {
            Debug.Log("HELLO PLAYER");
            OpenQuizPanel();
            activeQuestion = 0;
            UpdateQuizPanel();
        }
    }

    void UpdateQuizPanel()
    {
        Debug.Log($"CALLED FROM UPDATEQUIZPANEL, activeQuestion is {activeQuestion}");
        GameObject questionPrompt = quizPanel.transform.Find("QuestionPromptText").gameObject;

        GameObject option1 = quizPanel.transform.Find("QuestionRadioButtons/Option1/Label").gameObject;
        GameObject option2 = quizPanel.transform.Find("QuestionRadioButtons/Option2/Label").gameObject;
        GameObject option3 = quizPanel.transform.Find("QuestionRadioButtons/Option3/Label").gameObject;

        questionPrompt.GetComponent<TMP_Text>().text = (activeQuestion + 1) + ". " + compiledQuestions[activeQuestion];
        option1.GetComponent<Text>().text = compiledOptions[activeQuestion][0];
        option2.GetComponent<Text>().text = compiledOptions[activeQuestion][1];
        option3.GetComponent<Text>().text = compiledOptions[activeQuestion][2];

        for (int i = 0; i < 3; i++)
        {
            toggle[i].isOn = false;
        }

        for (int i = 0; i < 3; i++)
        {
            if (userAnswers[activeQuestion] == i)
            {
                toggle[i].isOn = true;
                break;
            }
        }
    }

    void OpenQuizPanel()
    {
        Time.timeScale = 0;
        quizPanel.SetActive(true);
    }

    void CloseQuizPanel()
    {
        GameObject activeToggle = toggleGroup.ActiveToggles().FirstOrDefault().gameObject;

        for (int i = 0; i < 3; i++)
        {
            if (activeToggle.name == "Option" + (i + 1))
            {
                userAnswers[activeQuestion] = i;
            }
        }
        Debug.Log("Clicked CloseQuizPanel");
        Time.timeScale = 1;
        quizPanel.SetActive(false);
    }

    void NextQuestion()
    {
        GameObject activeToggle = toggleGroup.ActiveToggles().FirstOrDefault().gameObject;

        for (int i = 0; i < 3; i++)
        {
            if (activeToggle.name == "Option" + (i + 1))
            {
                if (activeQuestion < 2)
                {
                    userAnswers[activeQuestion] = i;
                    activeQuestion++;
                    UpdateQuizPanel();
                }
                else
                {
                    userAnswers[activeQuestion] = i;
                    ShowQuizResults();
                }
                Debug.Log($"WENT FORWARD, active question is {activeQuestion}");
                // Debug.Log($"User selected option {i + 1}, adding {i} into userAnswers");
                break;
            }
        }
    }

    void PreviousQuestion()
    {
        GameObject activeToggle = toggleGroup.ActiveToggles().FirstOrDefault().gameObject;

        for (int i = 0; i < 3; i++)
        {
            if (activeToggle.name == "Option" + (i + 1))
            {
                if (activeQuestion > 0)
                {
                    userAnswers[activeQuestion] = i;
                    activeQuestion--;
                    UpdateQuizPanel();
                }
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

        quizPanel.SetActive(false);
        gameManagerScript.LevelCompletedQuiz(userScore);
    }
}


*/