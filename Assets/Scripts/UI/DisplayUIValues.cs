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
    [SerializeField] Image lifeSaveButton, deathSaveButton;

    public static event Action<int> OnDeathSaveChange;
    public static event Action<int> OnLifeSaveChange;

    bool lifeSaveOn = true;
    bool deathSaveOn = true;


    int lifeSaveLastValue, deathSaveLastValue;

    void Start()
    {
        lifeSaveLastValue = (int)sliderLifeSave.value;
        deathSaveLastValue = (int)sliderDeathSave.value;

        lifeSaveOn = true;
        deathSaveOn = true;
        SetColor(lifeSaveButton, lifeSaveOn);
        SetColor(deathSaveButton, deathSaveOn);
    }

    public void SetValue(int value)
    {
        text.text = value.ToString();
    }

    private void SetColor(Image image, bool on)
    {
        if (on) image.color = Color.black;
        else image.color = Color.white;
    }

    public void SetLifeSaveOn()
    {
        lifeSaveOn = !lifeSaveOn;
        sliderLifeSave.interactable = lifeSaveOn;

        SetColor(lifeSaveButton, lifeSaveOn);

        if (lifeSaveOn)
        {
            sliderLifeSave.value = lifeSaveLastValue;
        } else
        {
            lifeSaveLastValue = (int) sliderLifeSave.value; 
            sliderLifeSave.value = 0;
        }
    }

    public void SetDeathSaveOn()
    {
        deathSaveOn = !deathSaveOn;
        sliderDeathSave.interactable = deathSaveOn;

        SetColor(deathSaveButton, deathSaveOn);

        if (deathSaveOn)
        {
            sliderDeathSave.value = deathSaveLastValue;
            if (sliderDeathSave.value > sliderLifeSave.value) sliderDeathSave.value = sliderLifeSave.value;
        } else
        {
            deathSaveLastValue = (int) sliderDeathSave.value;
            sliderDeathSave.value = 0;
        }
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
