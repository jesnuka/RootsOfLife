using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LifeProbabilityListener : MonoBehaviour
{
    [SerializeField] Slider slider;

    public static event Action<int> OnLifeProbabilityUpdated;

    public void UpdateLifeProbability()
    {
        OnLifeProbabilityUpdated?.Invoke((int)slider.value);
    }
}
