using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RuleButton : MonoBehaviour
{
    [SerializeField] Image[] imagesAliveRule;
    [SerializeField] Image[] imagesDeadRule;
    [field:SerializeField] public bool[] ButtonsCheckedAliveRule { get; private set; }
    [field: SerializeField] public bool[] ButtonsCheckedDeadRule { get; private set; }

    public static event Action<bool[]> OnAliveRuleChange;
    public static event Action<bool[]> OnDeadRuleChange;

    public void Start()
    {
        for (int i = 0; i < ButtonsCheckedAliveRule.Length; i++)
        {
            DisplayVisuals(ButtonsCheckedAliveRule, imagesAliveRule, i);

        }

        for (int i = 0; i < ButtonsCheckedDeadRule.Length; i++)
        {
            DisplayVisuals(ButtonsCheckedDeadRule, imagesDeadRule, i);
        }

        OnAliveRuleChange?.Invoke(ButtonsCheckedAliveRule);
        OnDeadRuleChange?.Invoke(ButtonsCheckedDeadRule);
    }

    public void OnAliveClick(int i)
    {
        ButtonsCheckedAliveRule[i] = !ButtonsCheckedAliveRule[i];
        DisplayVisuals(ButtonsCheckedAliveRule, imagesAliveRule, i);
        OnAliveRuleChange?.Invoke(ButtonsCheckedAliveRule);
    }

    public void OnDeadClick(int i)
    {
        ButtonsCheckedDeadRule[i] = !ButtonsCheckedDeadRule[i];
        DisplayVisuals(ButtonsCheckedDeadRule, imagesDeadRule, i);
        OnDeadRuleChange?.Invoke(ButtonsCheckedDeadRule);
    }

    private void DisplayVisuals(bool[] b, Image[] l, int i)
    {
        if (b[i])
        {
            l[i].color = Color.black;
        }
        else
        {
            l[i].color = Color.white;
        }
    }
}
