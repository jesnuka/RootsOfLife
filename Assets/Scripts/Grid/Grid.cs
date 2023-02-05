using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [field: SerializeField] private CellFactory _cellFactory;
    public CellFactory CellFactory { get { return _cellFactory; } set { _cellFactory = value; } }

    [field:SerializeField]private RectTransform _gridObject;
    public RectTransform GridObject { get { return _gridObject; } set { _gridObject = value; } }

    // List of Rows that contain Cells
    [field: SerializeField] private Row[] _rows;
    public Row[] Rows { get { return _rows; } set { _rows = value; } }

    private int _columnAmount;
  //  public int ColumnAmount { get { return GameSettings.ColumnAmount; } }
    public int ColumnAmount { get { return _columnAmount; } set { _columnAmount = value; } }

    private int _rowAmount;
   // public int RowAmount { get { return GameSettings.RowAmount; } }
    public int RowAmount { get { return _rowAmount; } set { _rowAmount = value; } }

    private int _cellAmount;
    public int CellAmount { get { return _cellAmount; } set { _cellAmount = value; } }

    private GameSettings _gameSettings;
    public GameSettings GameSettings { get { return _gameSettings; } set { _gameSettings = value; } }

    private int _cellsUpdated;
    public int CellsUpdated { get { return _cellsUpdated; } set { _cellsUpdated = value; } }

    public void CreateGrid(GameSettings gameSettings)
    {
        GridObject.sizeDelta = new Vector2(
        (RowAmount - 1) * CellFactory.GetCellSize().x,
        (ColumnAmount - 1) * CellFactory.GetCellSize().y
        );

        GameSettings = gameSettings;
        ColumnAmount = gameSettings.ColumnAmount;
        RowAmount = gameSettings.RowAmount;

        Rows = new Row[RowAmount];

        for (int y = 0; y < RowAmount; y++)
        {
            Vector3 rowPosition = new Vector3(0.0f, y * CellFactory.GetCellSize().y, 0.0f);
            Row row = CellFactory.CreateRow(ColumnAmount, rowPosition, GridObject.transform);
            Rows[y] = row;

            for (int x = 0; x < ColumnAmount; x++)
            {
                Vector3 columnPosition = new Vector3(x * CellFactory.GetCellSize().x, 0.0f, 0.0f);
                Cell cell = CellFactory.CreateCell(columnPosition, row.gameObject.transform);
                cell.SetPosition(x, y);
                Rows[y].Cells[x] = cell;

            }
        }

        CellAmount = ColumnAmount * RowAmount;
        Debug.Log("Cell Amount = " + CellAmount);
    }

    public Cell[] GetNeighbors(GridPosition position)
    {
        Cell[] neighbors = new Cell[8];
        int index = 0;
        for(int x = position.Column - 1; x <= position.Column+1; x++)
        {
            for (int y = position.Row - 1; y <= position.Row+1; y++)
            {
                if (x == position.Column && y == position.Row)
                    continue;
                if (x < 0 || x >= ColumnAmount || y < 0 || y >= RowAmount)
                    neighbors[index] = null;
                else 
                    neighbors[index] = Rows[y].Cells[x];
                index += 1;
            }
        }
        
        return neighbors;
    }

    public void Restart()
    {
        //TODO implement setting every cell to dead.
    }
}
