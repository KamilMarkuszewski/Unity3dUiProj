using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class UiObject : UiObjectBase
    {
        public UiObject(float x, float y, Transform prefab) : base(x, y, prefab)
        {
        }

        public bool IsPopup { get; set; }
    }
}
