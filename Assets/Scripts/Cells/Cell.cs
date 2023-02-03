using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private Grid _grid;
    public Grid Grid { get { return _grid; } set { _grid = value; } }

    private GridPosition _position;
    public GridPosition Position { get { return _position; } set { _position = value; } }


    [field: SerializeField] private CellVisuals _cellVisuals;
    public CellVisuals CellVisuals { get { return _cellVisuals; } set { _cellVisuals = value; } }

    private bool _isAlive;
    public bool IsAlive { get { return _isAlive; } set { _isAlive = value; } }

    public Cell(Grid grid)
    {
        Grid = grid;
    }

    public void SetPosition(int column, int row)
    {
        if (Position == null)
            Position = new GridPosition(column, row);
        else
            Position.SetPosition(column, row);

    }

    public void ToggleCell(bool value)
    {
        IsAlive = value;
        CellVisuals.ToggleCell(value);
    }

    public Vector2 GetSize()
    {
        return CellVisuals.GetSize();
    }

}
