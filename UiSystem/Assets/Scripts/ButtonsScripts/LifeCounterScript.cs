using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ButtonsScripts
{
    public class LifeCounterScript : MonoBehaviour
    {
        private int _previousLifes;

        // Wiem że to nie najlepszy pomysł, ale po prostu nie na tym się skupiam. Ta klasa jest ogólnie zle napisana.
        public Transform Hearth1;
        public Transform Hearth2;
        public Transform Hearth3;
        public Transform Hearth4;
        public Transform Hearth5;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_previousLifes != GameController.GetLifes() && GameController.IsInitialized)
            {
                _previousLifes = GameController.GetLifes();
                DeactivateSprites();

                switch (GameController.GetLifes())
                {
                    case 1:
                        Hearth1.gameObject.SetActive(true);
                        break;
                    case 2:
                        Hearth1.gameObject.SetActive(true);
                        Hearth2.gameObject.SetActive(true);
                        break;
                    case 3:
                        Hearth1.gameObject.SetActive(true);
                        Hearth2.gameObject.SetActive(true);
                        Hearth3.gameObject.SetActive(true);
                        break;
                    case 4:
                        Hearth1.gameObject.SetActive(true);
                        Hearth2.gameObject.SetActive(true);
                        Hearth3.gameObject.SetActive(true);
                        Hearth4.gameObject.SetActive(true);
                        break;
                    case 5:
                        Hearth1.gameObject.SetActive(true);
                        Hearth2.gameObject.SetActive(true);
                        Hearth3.gameObject.SetActive(true);
                        Hearth4.gameObject.SetActive(true);
                        Hearth5.gameObject.SetActive(true);
                        break;
                }
            }
        }

        private void DeactivateSprites()
        {
            Hearth1.gameObject.SetActive(false);
            Hearth2.gameObject.SetActive(false);
            Hearth3.gameObject.SetActive(false);
            Hearth4.gameObject.SetActive(false);
            Hearth5.gameObject.SetActive(false);
        }
    }
}
