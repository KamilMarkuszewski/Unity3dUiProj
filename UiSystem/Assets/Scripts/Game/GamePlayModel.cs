using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class GamePlayModel
    {
        private int _lifes;
        private int _points;
        public float MaxTime;
        public int StartLifes;
        public float Timer { get; set; }
        public bool TimeEnded { get; set; }

        public int GetLifes()
        {
            return _lifes;
        }

        public void Restart()
        {
            _lifes = StartLifes;
            TimeEnded = false;
            Timer = MaxTime;
        }

        public void LifeLost()
        {
            _lifes--;
        }

        public void AddPoint()
        {
            _points++;
        }

        public int GetPoints()
        {
            return _points;
        }

        public bool GameOver
        {
            get { return GameController.GetLifes() <= 0 || TimeEnded; }
        }



    }
}
