using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellRules_Roots : CellRules
{
    public override bool CheckRules(Cell cell, int aliveNeighbors, bool currentState)
    {
        bool newState = false;

        int rand = Random.Range(2, 5);

        if (currentState)
        {
           // if (aliveNeighbors == 2 || aliveNeighbors == 3 || aliveNeighbors >= )
            if (aliveNeighbors <= 4)
                newState = true;
        }
        else
        {
            if (aliveNeighbors <= 3 && aliveNeighbors > 0 && rand == 4 &&
                (cell.IsNeighborAlive(1) || cell.IsNeighborAlive(3) || cell.IsNeighborAlive(4) || cell.IsNeighborAlive(6)))
                newState = true;
        }


        return newState;
    }
}
