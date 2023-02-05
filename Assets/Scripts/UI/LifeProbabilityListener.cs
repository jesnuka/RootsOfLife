using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LifeProbabilityListener : MonoBehaviour
{
    [SerializeField] Slider slider;

    public static event Action<float> OnLifeProbabilityUpdated;

    public void Start()
    {
        UpdateLifeProbability();
    }

    public void UpdateLifeProbability()
    {
        OnLifeProbabilityUpdated?.Invoke(slider.value);
    }
}
