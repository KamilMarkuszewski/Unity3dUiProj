using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ButtonsScripts
{
    public class PointsScript : UiWriter
    {
        private int _previousPoints;


        // znów, to nie jest chyba najlepszy pomysł ale nie na tym sie skupiam a poza tym chcę móc podpinać to z poziomu edytora unity3d
        public Transform Digit1;
        public Transform Digit2;
        public Transform Digit3;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            int points = GameController.GetPoints();
            if (_previousPoints != GameController.GetPoints() && GameController.IsInitialized)
            {
                _previousPoints = points;

                ShowDigitSprite(points, 1, Digit1);
                ShowDigitSprite(points, 2, Digit2);
                ShowDigitSprite(points, 3, Digit3);
            }
        }


    }
}
