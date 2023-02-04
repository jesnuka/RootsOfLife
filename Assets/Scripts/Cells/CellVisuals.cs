using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellVisuals : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _spriteRenderer;
    [SerializeField] private CellSpriteManager _cellSpriteManager;
    [SerializeField] private Cell _cell;

    public RectTransform RectTransform { get { return _rectTransform; } }

    public void ToggleCell(bool value)
    {
        if (_spriteRenderer != null && _spriteRenderer != null)
        {
            _spriteRenderer.sprite = _cellSpriteManager.GetSprite(0);
        }

        //foreach
    }

    public Vector2 GetSize()
    {
        return new Vector2(RectTransform.sizeDelta.x, RectTransform.sizeDelta.y);
    }
}
