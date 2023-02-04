using System;
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
    [field: SerializeField] private bool _currentState;
    public bool CurrentState { get { return _currentState; } set { _currentState = value; } }

    [field: SerializeField] private int _deathSaves;
    public int DeathSaves { get { return _deathSaves; } set { _deathSaves = value;  } }

    [field: SerializeField] private int _lifeSaves;
    public int LifeSaves { get { return _lifeSaves; } set { _lifeSaves = value; } }

    // The next state of the cell that will be applied at the end of current turn
    [field: SerializeField] private bool _nextState;
    public bool NextState { get { return _nextState; } set { _nextState = value; } }

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
        if(value == false)
        {
            DeathSaves += 1;
            if (DeathSaves >= 2)
            {
                LifeSaves = 0;
                CurrentState = false;
            }
            UpdateVisuals();
        }
        else
        {
            if (CurrentState == true)
                LifeSaves += 1;
            if(LifeSaves >= 5)
            {
                CurrentState = false;
                UpdateVisuals();
            }
            else
            {
                DeathSaves = 0;
                CurrentState = true;
                UpdateVisuals();
            }
        }
    }

    public void UpdateVisuals()
    {
        CellVisuals.ToggleCell();
    }
    
    public void CellClicked()
    {
        ToggleCell(!CurrentState);
        NotifyNeighbors();
    }

    private void NotifyNeighbors()
    {
        Cell[] neighbors = GetNeighbors();
        for (int i = 0; i < neighbors.Length; i++)
        {
            if (neighbors[i] == null)
                continue;

            neighbors[i].CalculateNextState();
        }
    }

    public Vector2 GetSize()
    {
        return CellVisuals.GetSize();
    }

    public void UpdateCellState()
    {
        ToggleCell(NextState);
    }

    public void CalculateNextState()
    {
        Cell[] neighbors = GetNeighbors();
        int aliveNeighbors = CountAliveNeighbors(neighbors);
        NextState = CellRules.GetAliveState(this, aliveNeighbors, CurrentState);
    }

    public Cell[] GetNeighbors()
    {
        return Grid.GetNeighbors(Position);
    }

    public bool IsNeighborAlive(int index)
    {
        bool isAlive = false;
        Cell neighbor = GetNeighbors()[index];
        if (neighbor != null)
            isAlive = neighbor.CurrentState;

        return isAlive;
    }

    public int CountAliveNeighbors(Cell[] neighbors)
    {
        int aliveNeighbors = 0;
      
        for(int i = 0; i < neighbors.Length; i++)
        {
            if (neighbors[i] == null)
                continue;
            
            if (neighbors[i].CurrentState)
                aliveNeighbors += 1;

        }

        return aliveNeighbors;
    }
    

}
