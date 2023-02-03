using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellFactory : MonoBehaviour
{
    private Grid _grid;
    public Grid Grid { get { return _grid; } set { _grid = value; } }

    [SerializeField] private GameObject _cellPrefab;
    public GameObject CellPrefab { get { return _cellPrefab; } }

    [SerializeField] private GameObject _rowPrefab;
    public GameObject RowPrefab { get { return _rowPrefab; } }

    public Cell CreateCell(Vector3 position, Transform parent)
    {
        GameObject cellObject = Instantiate(CellPrefab, position, Quaternion.identity);
        cellObject.transform.SetParent(parent, false);
        Cell cell = cellObject.GetComponent<Cell>();
        cell.Grid = Grid;

        return cell;
    }

    public Row CreateRow(int columnAmount, Vector3 position, Transform parent)
    {
        GameObject rowObject = Instantiate(RowPrefab, position, Quaternion.identity);
        rowObject.transform.SetParent(parent, false);
        Row row = rowObject.GetComponent<Row>();
        row.Cells = new Cell[columnAmount];

        return row;
    }

    public Vector2 GetCellSize()
    {
        return CellPrefab.GetComponent<Cell>().GetSize();
    }
}
