using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [field: SerializeField] private CellFactory _cellFactory;
    public CellFactory CellFactory { get { return _cellFactory; } set { _cellFactory = value; } }

    [field:SerializeField]private RectTransform _gridObject;
    public RectTransform GridObject { get { return _gridObject; } set { _gridObject = value; } }

    // List of Rows that contain Cells
    [field: SerializeField] private Row[] _rows;
    public Row[] Rows { get { return _rows; } set { _rows = value; } }

    private int _columnAmount;
  //  public int ColumnAmount { get { return GameSettings.ColumnAmount; } }
    public int ColumnAmount { get { return _columnAmount; } set { _columnAmount = value; } }

    private int _rowAmount;
   // public int RowAmount { get { return GameSettings.RowAmount; } }
    public int RowAmount { get { return _rowAmount; } set { _rowAmount = value; } }

    private GameSettings _gameSettings;
    public GameSettings GameSettings { get { return _gameSettings; } set { _gameSettings = value; } }

    // Start is called before the first frame update
    void Start()
    {

    }
    
    void Update()
    {
        
    }

    public void CreateGrid(GameSettings gameSettings)
    {
        GridObject.sizeDelta = new Vector2(
        (RowAmount - 1) * CellFactory.GetCellSize().x,
        (ColumnAmount - 1) * CellFactory.GetCellSize().y
        );

        GameSettings = gameSettings;
        ColumnAmount = gameSettings.ColumnAmount;
        RowAmount = gameSettings.RowAmount;

        Debug.Log("ColumnAmount is: " + ColumnAmount);

        Rows = new Row[RowAmount];

        for (int y = 0; y < RowAmount; y++)
        {
            Vector3 rowPosition = new Vector3(0.0f, y * CellFactory.GetCellSize().y, 0.0f);
            Row row = CellFactory.CreateRow(ColumnAmount, rowPosition, GridObject.transform);
            Rows[y] = row;

            for (int x = 0; x < ColumnAmount; x++)
            {
                Vector3 columnPosition = new Vector3(x * CellFactory.GetCellSize().x, 0.0f, 0.0f);
                Cell cell = CellFactory.CreateCell(columnPosition, row.gameObject.transform);
                cell.SetPosition(x, y);
                Rows[y].Cells[x] = cell;

            }
        }
    }
}
