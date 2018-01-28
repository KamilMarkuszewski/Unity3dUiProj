using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class GameGuiScript : MonoBehaviour
    {
        public Transform ObjectPrefab;
        public Transform Popup;
        public Sprite SpriteGreen;
        public Sprite SpriteRed;

        void Start()
        {
            UiSystemService.Instance.OnStart();
            UiSystemService.Instance.ReCreateObjects(ObjectPrefab);
            GameController.OnStart();
        }

        void Awake()
        {
            GameController.Init(UiSystemService.Instance.UiObjects, 5, 30f, SpriteGreen, SpriteRed);
            GameController.GameOver += GameControllerOnGameOver;
            UiSystemService.Instance.OnAwake();
            GameController.OnAwake();
        }

        private void GameControllerOnGameOver(object sender, EventArgs eventArgs)
        {
            UiSystemService.Instance.AddUiButton(1000, 1000, Popup, true);
        }

        void Update()
        {
            UiSystemService.Instance.OnUpdate();
            GameController.OnUpdate();
        }
    }
}
