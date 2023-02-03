using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [field: SerializeField] private int _columnAmount;
    public int ColumnAmount { get { return _columnAmount; } set { _columnAmount = value; } }
    [field: SerializeField] private int _maxColumnAmount;
    public int MaxColumnAmount { get { return _maxColumnAmount; } set { _maxColumnAmount = value; } }
    [field: SerializeField] private int _rowAmount;
    public int RowAmount { get { return _rowAmount; } set { _rowAmount = value; } }
    [field: SerializeField] private int _maxRowAmount;
    public int MaxRowAmount { get { return _maxRowAmount; } set { _maxRowAmount = value; } }
}
