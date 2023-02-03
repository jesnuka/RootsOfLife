using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPosition
{
    private int _column;
    public int Column { get { return _column; } set { _column = value; } }

    private int _row;
    public int Row { get { return _row; } set { _row = value; } }

    public GridPosition(int column, int row)
    {
        _column = column;
        _row = row;
    }
    public void SetPosition(int column, int row)
    {
        _column = column;
        _row = row;
    }
}
