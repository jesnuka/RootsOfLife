using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [field: SerializeField] private UIHandlerType _handlerType;
    public UIHandlerType HandlerType { get { return _handlerType; } set { _handlerType = value; } }

    [field: SerializeField] private ButtonListener _buttonListener;
    public ButtonListener ButtonListener { get { return _buttonListener; } set { _buttonListener = value; } }

    [field: SerializeField] private GameObject _firstImage;
    public GameObject FirstImage { get { return _firstImage; } set { _firstImage = value; } }
    [field: SerializeField] private GameObject _secondImage;
    public GameObject SecondImage { get { return _secondImage; } set { _secondImage = value; } }
    private bool _state;
    public bool State { get { return _state; } set { _state = value; } }

    public enum UIHandlerType
    {
        Other,
        PauseButton
    }

    private void Awake()
    {
        SetupHandler();
    }

    private void SetupHandler()
    {
        if (HandlerType == UIHandlerType.PauseButton)
            ButtonListener = new ButtonListener_Pause();
    }

    public void ToggleImage(bool value)
    {
        if (FirstImage == null || SecondImage == null)
            return;
        State = value;
        FirstImage.SetActive(!State);
        SecondImage.SetActive(State);
    }

    private void Start()
    {
        if (ButtonListener != null)
            ButtonListener.InitializeListener(this);
    }
}
