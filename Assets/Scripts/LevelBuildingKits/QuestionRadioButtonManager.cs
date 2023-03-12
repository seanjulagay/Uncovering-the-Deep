using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestionRadioButtonManager : MonoBehaviour
{
    ToggleGroup toggleGroup;

    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    public void NextButton()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();

    }
}
