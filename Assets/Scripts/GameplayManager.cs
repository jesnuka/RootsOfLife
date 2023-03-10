using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static event Action<bool> onPause;

    [SerializeField] private Grid _grid;
    public Grid Grid { get { return _grid; } set { _grid = value; } }

    [field: SerializeField] private GameSettings _gameSettings;
    public GameSettings GameSettings { get { return _gameSettings; } set { _gameSettings = value; } }

    [SerializeField] DisplayUIValues ui;

  //  public static event Action onCheckingFinished;
  //  public static event Action onUpdateFinished;

    private bool _isUpdating;
    public bool IsUpdating { get { return _isUpdating; } set { _isUpdating = value; } }
    
    private bool _isPaused;
    public bool IsPaused { get { return _isPaused; } set { _isPaused = value; } }

    private int _iterations;
    public int Iterations { get { return _iterations; } set { _iterations = value; } }

    private void Start()
    {
      //  onUpdateFinished += StartGridUpdate;
        Grid.CreateGrid(GameSettings);
        Iterations = 0;
        ui.SetValue(Iterations);
        TogglePause();

        StartGridUpdate();
    }

    public void TogglePause()
    {
        IsPaused = !IsPaused;
        onPause?.Invoke(IsPaused);
    }

    public void Restart()
    {
        IsPaused = true;
        onPause?.Invoke(IsPaused);

        Grid.Restart();
        Iterations = 0;
        ui.SetValue(Iterations);
    }

    /*public void FinishUpdate()
    {
        IsUpdating = false;
      //  onUpdateFinished?.Invoke();
    }*/

    public void ChangeSettings(GameSettings newSettings)
    {
        GameSettings = newSettings;
    }

    private void StartGridUpdate()
    {
        StartCoroutine(WaitForTurn());
    }

    IEnumerator WaitForTurn()
    {
        yield return new WaitForSeconds(GameSettings.TurnSpeed);
        if (!IsUpdating && !IsPaused)
            UpdateGrid();
        else if(!IsUpdating && IsPaused)
            StartCoroutine(WaitForTurn());
    }

    private void UpdateGrid()
    {
        Iterations += 1;
        ui.SetValue(Iterations);

        IsUpdating = true;

        // Perform grid check for next state
        for(int x = 0; x < Grid.ColumnAmount; x++)
        {
            for (int y = 0; y < Grid.RowAmount; y++)
            {
                Grid.Rows[y].Cells[x].CalculateNextState();
            }
        }

     //   onCheckingFinished?.Invoke();

        // Perform grid update
        for (int x = 0; x < Grid.ColumnAmount; x++)
        {
            for (int y = 0; y < Grid.RowAmount; y++)
            {
                Grid.Rows[y].Cells[x].UpdateCellState();
            }
        }
        for (int x = 0; x < Grid.ColumnAmount; x++)
        {
            for (int y = 0; y < Grid.RowAmount; y++)
            {
                Grid.Rows[y].Cells[x].UpdateVisuals();
            }
        }

        IsUpdating = false;

        StartCoroutine(WaitForTurn());
        // FinishUpdate();
    }
}
