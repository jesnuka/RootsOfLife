using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private Cell[] _cells;
    public Cell[] Cells { get { return _cells; } set { _cells = value; } }
}
