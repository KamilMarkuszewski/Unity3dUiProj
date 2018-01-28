using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ButtonsScripts
{
    public class PlayButton : MonoBehaviour
    {
        void OnMouseDown()
        {
            if (GameController.IsInitialized)
            {
                GameController.Shuffle();
                GameController.Restart();
            }
        }
    }
}
