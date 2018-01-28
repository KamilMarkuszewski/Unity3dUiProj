using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class UiObjectBase
    {
        public Transform GameObjectTransform;

        protected Vector3 Position;
        protected Vector3 Scale;
        protected bool IsSaved;
        protected Transform Prefab;

        protected UiObjectBase(float x, float y, Transform prefab)
        {
            var gameObj = UnityEngine.Object.Instantiate(prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
            gameObj.localScale = new Vector3(x, y, 0);
            GameObjectTransform = gameObj;
            Prefab = prefab;
        }

        public virtual void ReCreate(Transform objectPrefab)
        {
            if (!IsSaved)
            {
                return;
            }
            Prefab = objectPrefab;

            ReCreate();
        }

        public virtual void ReCreate()
        {
            if (!IsSaved)
            {
                return;
            }

            GameObjectTransform = UnityEngine.Object.Instantiate(Prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
            GameObjectTransform.localScale = new Vector3(Scale.x, Scale.y, Scale.z);
            GameObjectTransform.position = Position;
            IsSaved = false;
        }

        public virtual void SaveStateAndDestroy()
        {
            if (IsSaved)
            {
                return;
            }

            var tr = GameObjectTransform.position;
            var scale = GameObjectTransform.localScale;
            Position = new Vector3(tr.x, tr.y, tr.z);
            Scale = new Vector3(scale.x, scale.y, scale.z);
            UnityEngine.Object.Destroy(GameObjectTransform.gameObject);
            IsSaved = true;
        }

        public virtual void Destroy()
        {
            UnityEngine.Object.Destroy(GameObjectTransform.gameObject);
        }


    }
}
