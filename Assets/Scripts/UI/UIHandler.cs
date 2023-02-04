using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [field: SerializeField] private GameObject _firstImage;
    public GameObject FirstImage { get { return _firstImage; } set { _firstImage = value; } }
    [field: SerializeField] private GameObject _secondImage;
    public GameObject SecondImage { get { return _secondImage; } set { _secondImage = value; } }
    private bool _state;
    public bool State { get { return _state; } set { _state = value; } }

    public void ToggleImage()
    {
        if (FirstImage == null || SecondImage == null)
            return;
        State = !State;
        FirstImage.SetActive(!State);
        SecondImage.SetActive(State);
    }
}
