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

    // The current state of the cell
    [field: SerializeField] private bool _isAlive;
    public bool IsAlive { get { return _isAlive; } set { _isAlive = value; } }

    // The next state of the cell that will be applied at the end of current turn
    [field: SerializeField] private bool _nextState;
    public bool NextState { get { return _nextState; } set { _nextState = value; } }
    private void Start()
    {
        GameplayManager.onCheckingFinished += UpdateCellState;
    }
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
    
    public void CellClicked()
    {
        Debug.Log("Clicked");
        ToggleCell(!IsAlive);
    }

    public Vector2 GetSize()
    {
        return CellVisuals.GetSize();
    }

    public void UpdateCellState()
    {
        Debug.Log(" Updated State ");
        ToggleCell(NextState);
    }

    public void CalculateNextState()
    {
        Cell[] neighbors = GetNeighbors();
        int aliveNeighbors = CountAliveNeighbors(neighbors);
        bool nextState = CellRules.GetAliveState(neighbors.Length, aliveNeighbors, IsAlive);
        NextState = nextState;
    }

    public Cell[] GetNeighbors()
    {
        Cell[] neighbors = new Cell[8];
        Grid.GetNeighbors(Position);
        return neighbors;
    }

    public int CountAliveNeighbors(Cell[] neighbors)
    {
        int aliveNeighbors = 0;
      
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
