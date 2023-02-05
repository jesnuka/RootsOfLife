using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DeathProbabilityListener : MonoBehaviour
{
    [SerializeField] Slider slider;

    public static event Action<float> OnDeathProbabilityUpdated;

    public void Start()
    {
        UpdateDeathProbability();
    }

    public void UpdateDeathProbability()
    {
        OnDeathProbabilityUpdated?.Invoke(slider.value);
    }
}
