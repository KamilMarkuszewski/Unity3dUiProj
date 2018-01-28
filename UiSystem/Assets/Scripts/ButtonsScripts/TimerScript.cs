using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ButtonsScripts
{
    public class TimerScript : UiWriter
    {
        // znów, to nie jest chyba najlepszy pomysł ale nie na tym sie skupiam a poza tym chcę móc podpinać to z poziomu edytora unity3d
        public Transform Digit1;
        public Transform Digit2;
        private int _previousTime;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            int time = (int)GameController.GetTimeLeft();
            if (_previousTime != GameController.GetPoints() && GameController.IsInitialized)
            {
                _previousTime = time;
            
                ShowDigitSprite(time, 1, Digit1);
                ShowDigitSprite(time, 2, Digit2);
            }
        }
    }
}
