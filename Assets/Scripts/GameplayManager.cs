using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    public Grid Grid { get { return _grid; } set { _grid = value; } }

    [field: SerializeField] private GameSettings _gameSettings;
    public GameSettings GameSettings { get { return _gameSettings; } set { _gameSettings = value; } }

    private void Start()
    {
        Grid.CreateGrid(GameSettings);
    }

    public void ChangeSettings(GameSettings newSettings)
    {
        GameSettings = newSettings;
    }
}
