using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellRules
{
    public bool GetAliveState(Cell cell, int aliveNeighbors, bool currentState)
    {
        bool newState = CheckRules(cell, aliveNeighbors, currentState);

        return newState;
    }

    public abstract bool CheckRules(Cell cell, int aliveNeighbors, bool currentState);
}
