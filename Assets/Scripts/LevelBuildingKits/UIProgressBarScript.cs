using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class UIProgressBarScript : MonoBehaviour
{
    public int minimum;
    public int maximum;
    public int current;
    public Image mask;
    public Image fill;
    public Color highColor;
    public Color midColor;
    public Color lowColor;

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        Debug.Log("fillAmount: " + fillAmount);

        if (fillAmount > .66f)
        {
            fill.color = highColor;
        }
        else if (fillAmount > .33f && fillAmount <= .66f)
        {
            fill.color = midColor;
        }
        else
        {
            fill.color = lowColor;
        }
    }
}
