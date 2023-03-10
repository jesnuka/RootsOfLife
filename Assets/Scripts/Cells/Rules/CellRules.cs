using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellRules
{
    [field: SerializeField] private float _randomMaxAlive;
    public float RandomMaxAlive { get { return _randomMaxAlive; } set { _randomMaxAlive = value; } }

    [field: SerializeField] private float _randomMaxDead;
    public float RandomMaxDead { get { return _randomMaxDead; } set { _randomMaxDead = value; } }

    // Check how which amounts of neighbors are allowed for alive Cells to stay alive
    private bool[] _aliveCellNeighborChecks;
    public bool[] AliveCellNeighborChecks { get { return _aliveCellNeighborChecks; } set { _aliveCellNeighborChecks = value; } }

    // Check how which amounts of neighbors are allowed for dead Cells to stay alive
    private bool[] _deadCellNeighborChecks;
    public bool[] DeadCellNeighborChecks { get { return _deadCellNeighborChecks; } set { _deadCellNeighborChecks = value; } }

    public bool GetAliveState(Cell cell, int aliveNeighbors, bool currentState)
    {
        bool newState = CheckRules(cell, aliveNeighbors, currentState);

        return newState;
    }

    public abstract bool CheckRules(Cell cell, int aliveNeighbors, bool currentState);
}
