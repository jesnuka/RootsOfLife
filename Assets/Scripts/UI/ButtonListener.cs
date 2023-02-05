using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonListener 
{
    private UIHandler _uiHandler;
    public UIHandler UIHandler { get { return _uiHandler; } set { _uiHandler = value; } }

    public abstract void SubscribeToEvents();
    public void InitializeListener(UIHandler uiHandler = null)
    {
        if (uiHandler != null)
            UIHandler = uiHandler;
        SubscribeToEvents();
    }
}
