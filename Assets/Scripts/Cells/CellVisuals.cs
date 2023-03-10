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

    public bool up, right, down, left;
    public Cell[] neighbors;

    public RectTransform RectTransform { get { return _rectTransform; } }

    public void ToggleCell(bool isSpecial = false)
    {
        if (_image == null || _cellSpriteManager == null) return;


        neighbors = _cell.GetNeighbors();

        up = neighbors[3]==null ? false : neighbors[3].CurrentState;
        right = neighbors[6] == null ? false : neighbors[6].CurrentState;
        down = neighbors[4] == null ? false : neighbors[4].CurrentState;
        left = neighbors[1] == null ? false : neighbors[1].CurrentState;


        if (_cell.CurrentState)
        {
            
            if (_cell.PlayerPlaced)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.Seed);
                RotateImage(new float[] { 0f, 90f, 180f, 270f });
            }
            else if (up && right && down && left)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.Plus);
                RotateImage(0f);
            }
            else if (up && right && down)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.T);
                RotateImage(0f);
            }
            else if (right && down && left)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.T);
                RotateImage(90f);
            }
            else if (down && left && up)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.T);
                RotateImage(180f);
            }
            else if (left && up && right)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.T);
                RotateImage(270f);
            }
            else if (up && right)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.L);
                RotateImage(0f);
            }
            else if (right && down)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.L);
                RotateImage(90f);
            }
            else if (down && left)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.L);
                RotateImage(180f);
            }
            else if (left && up)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.L);
                RotateImage(270f);
            }
            else if (up && down)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.I);
                RotateImage(0f);
            }
            else if (right && left)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.I);
                RotateImage(90f);
            }
            else if (up)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.One);
                RotateImage(0f);
            }
            else if (right)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.One);
                RotateImage(90f);
            }
            else if (down)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.One);
                RotateImage(180f);
            }
            else if (left)
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.One);
                RotateImage(270f);
            } else
            {
                _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.Seed);
                RotateImage(new float[] { 0f, 90f, 180f, 270f });
            }
        }
        else
        {
            _image.sprite = _cellSpriteManager.GetSprite(CellSpriteManager.Shape.Empty);
            RotateImage(0f);
        }

    }

    private void RotateImage(float z)
    {
        _image.gameObject.transform.eulerAngles = new Vector3(_image.gameObject.transform.eulerAngles.x, _image.gameObject.transform.eulerAngles.y, -z);
    }

    private void RotateImage(float[] zs)
    {
        float z = zs[Random.Range(0, zs.Length)];
        RotateImage(z);
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
