using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public static class GameController
    {
        private static Sprite _spriteGreen;
        private static Sprite _spriteRed;
        private static List<UiGameObject> _collection;
        private static readonly GamePlayModel Model = new GamePlayModel();
        public static bool IsInitialized;
        public static bool IsStarted;
        public static event EventHandler GameOver;

        public static void Init(List<UiGameObject> collection, int startLifes, float maxTime, Sprite spriteGreen, Sprite spriteRed)
        {
            _collection = collection;
            Model.StartLifes = startLifes;
            Model.MaxTime = maxTime;
            _spriteGreen = spriteGreen;
            _spriteRed = spriteRed;
            IsInitialized = true;
        }

        public static float GetTimeLeft()
        {
            return Model.Timer;
        }

        public static void LifeLost()
        {
            if (Model.GameOver)
            {
                if (GameOver != null && IsStarted)
                {
                    GameOver(null, EventArgs.Empty);
                }
                return;
            }
            Model.LifeLost();
            
            Shuffle();
        }

        public static int GetLifes()
        {
            return Model.GetLifes();
        }


        public static void AddPoint()
        {
            if (Model.GameOver)
            {
                return;
            }
            Model.AddPoint();

            Shuffle();
        }

        public static int GetPoints()
        {
            return Model.GetPoints();
        }

        public static void OnUpdate()
        {
            if (Model.Timer > 0)
            {
                if (!Model.GameOver)
                {
                    Model.Timer -= Time.deltaTime;
                }
            }
            else if(!Model.TimeEnded)
            {
                if (GameOver != null && IsStarted)
                {
                    GameOver(null, EventArgs.Empty);
                }
                Model.TimeEnded = true;
            }
        }

        public static void OnStart()
        {

        }

        public static void OnAwake()
        {

        }

        public static void Restart()
        {
            UiSystemService.Instance.RemovePopups();
            Model.Restart();
            IsStarted = true;
        }


        public static void Shuffle()
        {
            if (_collection.Any())
            {
                var rnd = new System.Random();
                _collection.ForEach(o => o.IsATrap = true);
                _collection.ElementAt(rnd.Next(0, UiSystemService.Instance.UiObjects.Count)).IsATrap = false;
                _collection.ForEach(o => o.ApplyTrap(_spriteGreen, _spriteRed, LifeLost, AddPoint));
            }
        }
    }
}
