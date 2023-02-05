using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListener_Pause : ButtonListener
{
    public override void SubscribeToEvents()
    {
        GameplayManager.onPause += ToggleButton;
    }

    private void ToggleButton(bool value)
    {
        UIHandler.ToggleImage(value);
    }
}
