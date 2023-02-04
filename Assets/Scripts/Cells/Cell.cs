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
    public CellRules CellRules { get { return Grid.GameSettings.CurrentRules; } }

    // The current state of the cell
    [field: SerializeField] private bool _currentState;
    public bool CurrentState { get { return _currentState; } set { _currentState = value; } }

    [field: SerializeField] private int _deathSaves;
    public int DeathSaves { get { return Grid.GameSettings.DeathSaves; } }

    [field: SerializeField] private int _lifeSaves;
    public int LifeSaves { get { return Grid.GameSettings.LifeSaves; }}

    // The next state of the cell that will be applied at the end of current turn
    [field: SerializeField] private bool _nextState;
    public bool NextState { get { return _nextState; } set { _nextState = value; } }


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
            Grid.GameSettings.DeathSaves += 1;
            if (Grid.GameSettings.DeathSaves >= 2)
            {
                Grid.GameSettings.LifeSaves = 0;
                CurrentState = false;
            }
            UpdateVisuals();
        }
        else
        {
            if (CurrentState == true)
                Grid.GameSettings.LifeSaves += 1;
            if(Grid.GameSettings.LifeSaves >= 5)
            {
                CurrentState = false;
                UpdateVisuals();
            }
            else
            {
                Grid.GameSettings.DeathSaves = 0;
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
