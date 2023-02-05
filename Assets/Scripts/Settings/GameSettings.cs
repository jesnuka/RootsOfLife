using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [field: SerializeField] private int _columnAmount;
    public int ColumnAmount { get { return _columnAmount; } set { _columnAmount = value; } }
    [field: SerializeField] private int _rowAmount;
    public int RowAmount { get { return _rowAmount; } set { _rowAmount = value; } }
    [field: SerializeField] private float _turnSpeed;
    public float TurnSpeed { get { return _turnSpeed; } set { _turnSpeed = value; } }

    [field: SerializeField] private int _deathSavesMax;
    public int DeathSavesMax { get { return _deathSavesMax; } set { _deathSavesMax = value; } }

    [field: SerializeField] private int _lifeSavesMax;
    public int LifeSavesMax { get { return _lifeSavesMax; } set { _lifeSavesMax = value; } }

    private CellRules _currentRules;
    public CellRules CurrentRules { get { return _currentRules; } set { _currentRules = value; } }

    private void Awake()
    {
        SetupRules();
        HandleEvents();
    }

    private void Start()
    {

    }

    private void HandleEvents()
    {
        RuleButton.OnAliveRuleChange += ChangeAliveRules;
        RuleButton.OnDeadRuleChange += ChangeDeadRules;
        DisplayUIValues.OnDeathSaveChange += ChangeDeathSaveMax;
    }

    public void ChangeRandomMaxAlive(float newValue)
    {
        CurrentRules.RandomMaxAlive = newValue;
    }


    public void ChangeRandomMaxDead(float newValue)
    {
        CurrentRules.RandomMaxDead = newValue;
    }

    private void ChangeAliveRules(bool[] newRules)
    {
        CurrentRules.AliveCellNeighborChecks = newRules;
    }

    private void ChangeDeadRules(bool[] newRules)
    {
        CurrentRules.DeadCellNeighborChecks = newRules;
    }

    private void ChangeLifeSaveMax(int newValue)
    {
        LifeSavesMax = newValue;
    }

    private void ChangeDeathSaveMax(int newValue)
    {
        DeathSavesMax = newValue;
    }

    private void SetupRules()
    {
        CurrentRules = new CellRules_Roots();
        CurrentRules.AliveCellNeighborChecks = new bool[9];
        CurrentRules.DeadCellNeighborChecks = new bool[9];
    }

    public bool CheckDeathSaves(int deathSaves)
    {
        if (deathSaves >= DeathSavesMax)
            return true;

        else return false;
    }
    public bool CheckLifeSaves(int lifeSaves)
    {
        if (lifeSaves >= LifeSavesMax)
            return true;

        else return false;
    }
}
