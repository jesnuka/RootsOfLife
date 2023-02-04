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

    private CellRules _cellRules;
    public CellRules CellRules { get { return _cellRules; } set { _cellRules = value; } }


    [field: SerializeField] private bool _isAlive;
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
        if (IsAlive == value)
            return;

        IsAlive = value;
        CellVisuals.ToggleCell(value);
    }

    public Vector2 GetSize()
    {
        return CellVisuals.GetSize();
    }

    public void UpdateCellState()
    {
        Cell[] neighbors = Grid.GetNeighbors(Position);
        int aliveNeighbors = CountAliveNeighbors(neighbors);

        Debug.Log("Neighbors is: " + neighbors);
        Debug.Log("RULES is: " + CellRules);
        bool isAlive = CellRules.GetAliveState(neighbors.Length, aliveNeighbors, IsAlive);
        ToggleCell(isAlive);
    }

    public int CountAliveNeighbors(Cell[] neighbors)
    {
        int aliveNeighbors = 0;

     //   foreach (Cell cell in neighbors)
        for(int i = 0; i < neighbors.Length; i++)
        {
            if (neighbors[i] == null)
                continue;
            
            if (neighbors[i].IsAlive)
                aliveNeighbors += 1;

        }

        return aliveNeighbors;
    }
    

}
