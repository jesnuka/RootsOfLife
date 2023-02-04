using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellVisuals : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _image;
    [SerializeField] private CellSpriteManager _cellSpriteManager;
    [SerializeField] private Cell _cell;

    public RectTransform RectTransform { get { return _rectTransform; } }

    public void ToggleCell(bool value)
    {
        if (_image == null || _cellSpriteManager == null) return;


        //TODO: Logic for selecting the thing
        if (_cell.IsAlive) _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.Plus);
        else _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.Empty);

    }

    public Vector2 GetSize()
    {
        return new Vector2(RectTransform.sizeDelta.x, RectTransform.sizeDelta.y);
    }

    public void Update()
    {
        //FOR TESTING ONLY:
        //ToggleCell(false);
    }
}
