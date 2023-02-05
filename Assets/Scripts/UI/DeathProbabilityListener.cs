using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DeathProbabilityListener : MonoBehaviour
{
    [SerializeField] Slider slider;

    public static event Action<int> OnDeathProbabilityUpdated;

    public void UpdateDeathProbability()
    {
        OnDeathProbabilityUpdated?.Invoke((int)slider.value);
    }
}
