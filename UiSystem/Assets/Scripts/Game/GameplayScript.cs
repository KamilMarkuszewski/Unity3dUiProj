using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameplayScript : MonoBehaviour
{
    public event EventHandler OnMouseDownEvent;
    void OnMouseDown()
    {
        if (OnMouseDownEvent != null)
        {
            OnMouseDownEvent(this, EventArgs.Empty);
        }
    }
}
