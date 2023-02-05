using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DisplayUIValues : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider sliderDeathSave;
    [SerializeField] Slider sliderLifeSave;

    public static event Action<int> OnDeathSaveChange;
    public static event Action<int> OnLifeSaveChange;

    public void SetValue(int value)
    {
        text.text = value.ToString();
    }

    public void UpdateDeathSave()
    {
        if (sliderDeathSave.value > sliderLifeSave.value) sliderLifeSave.value = sliderDeathSave.value;
        OnDeathSaveChange?.Invoke((int)sliderDeathSave.value);
    }
    public void UpdateLifeSave()
    {
        if (sliderDeathSave.value > sliderLifeSave.value) sliderDeathSave.value = sliderLifeSave.value;
        OnLifeSaveChange?.Invoke((int)sliderLifeSave.value);
    }


}
