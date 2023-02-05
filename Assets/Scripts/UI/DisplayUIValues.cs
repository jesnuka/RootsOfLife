using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayUIValues : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    public void SetValue(int value)
    {
        text.text = value.ToString();
    }
}
