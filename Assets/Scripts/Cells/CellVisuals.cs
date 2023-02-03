using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellVisuals : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    public RectTransform RectTransform { get { return _rectTransform; } }

    public void ToggleCell(bool value)
    {

    }

    public Vector2 GetSize()
    {
        return new Vector2(RectTransform.sizeDelta.x, RectTransform.sizeDelta.y);
    }
}
