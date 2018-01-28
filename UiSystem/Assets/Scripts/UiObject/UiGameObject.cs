using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class UiGameObject : UiObjectBase
    {
        private Action _trapAction;
        private Action _action;

        public bool IsATrap; //Admiral Ackbar 

        public UiGameObject(float x, float y, Transform prefab) : base(x, y, prefab)
        {

        }

        public override void ReCreate(Transform objectPrefab)
        {
            base.ReCreate(objectPrefab);

            GameplayScript script = GameObjectTransform.gameObject.GetComponent<GameplayScript>();
            script.OnMouseDownEvent += ScriptOnOnMouseDownEvent;
        }

        private void ScriptOnOnMouseDownEvent(object sender, EventArgs eventArgs)
        {
            if (IsATrap)
            {
                if (_trapAction != null)
                {
                    _trapAction();
                }
            }
            else
            {
                if (_action != null)
                {
                    _action();
                }
            }
        }

        public void ApplyTrap(Sprite spriteGreen, Sprite spriteRed, Action trapAction, Action action)
        {
            var spriteRend = GameObjectTransform.gameObject.GetComponent<SpriteRenderer>();
            spriteRend.sprite = IsATrap ? spriteRed : spriteGreen;
            spriteRend.color = Color.white;
            _trapAction = trapAction;
            _action = action;
        }
    }
}
