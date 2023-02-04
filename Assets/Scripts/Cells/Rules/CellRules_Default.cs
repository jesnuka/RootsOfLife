using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellRules_Default : CellRules
{
    public override bool CheckRules(Cell cell, int aliveNeighbors, bool currentState)
    {
        bool newState = false;

        if(currentState)
        {
            if (aliveNeighbors == 2 || aliveNeighbors == 3)
                newState = true;
        }
        else
        {
            if (aliveNeighbors == 3)
                newState = true;
        }

        return newState;
    }
}
