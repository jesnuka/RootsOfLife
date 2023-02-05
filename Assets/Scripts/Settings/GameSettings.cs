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


    [field: SerializeField] private int _deathSaves;
    public int DeathSaves { get { return _deathSaves; } set { _deathSaves = value; } }

    [field: SerializeField] private int _lifeSaves;
    public int LifeSaves { get { return _lifeSaves; } set { _lifeSaves = value; } }

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
    }

    private void ChangeAliveRules(bool[] newRules)
    {
        CurrentRules.AliveCellNeighborChecks = newRules;
    }

    private void ChangeDeadRules(bool[] newRules)
    {
        CurrentRules.DeadCellNeighborChecks = newRules;
    }

    private void SetupRules()
    {
        CurrentRules = new CellRules_Roots();
        CurrentRules.AliveCellNeighborChecks = new bool[9];
        CurrentRules.DeadCellNeighborChecks = new bool[9];
    }

    public bool IncreaseDeathSaves()
    {
        DeathSaves += 1;
        if (DeathSaves >= DeathSavesMax)
            return true;
        else return false;
    }
    public bool IncreaseLifeSaves()
    {
        LifeSaves += 1;
        if (LifeSaves >= LifeSavesMax)
            return true;
        else return false;
    }

    public void ResetDeathSaves()
    {
        DeathSaves = 0;
    }

    public void ResetLifeSaves()
    {
        LifeSaves = 0;
    }




}
