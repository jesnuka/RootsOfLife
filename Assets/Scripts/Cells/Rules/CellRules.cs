using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellRules
{
    
    public bool GetAliveState(int neighborAmount, int aliveNeighbors, bool currentState)
    {
        int deadNeighbors = neighborAmount - aliveNeighbors;
        bool newState = CheckRules(neighborAmount, aliveNeighbors, currentState);

        return newState;
    }

    public abstract bool CheckRules(int neighborAmount, int aliveNeighbors, bool currentState);
}
