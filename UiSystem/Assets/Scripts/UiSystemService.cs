using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class UiSystemService
    {
        private static volatile UiSystemService _instance;
        private static readonly object SyncRoot = new object();

        private UiSystemService() { }

        public static UiSystemService Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                lock (SyncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new UiSystemService();
                    }
                }

                return _instance;
            }
        }



        public void OnUpdate()
        {
            SetCameraRect();
        }

        public void OnStart()
        {
        }

        public void OnAwake()
        {
        }

        private const float DefaultCameraXRatio = 1f;
        private const float DefaultCameraYRatio = 0.75f;
        private const float DefaultCameraWidth = 1024;
        private const float DefaultCameraHeight = 768f;
        private const float Margin = 0.07f;

        private static float _currentScaleXRatio = 1f;
        private static float _currentScaleYRatio = 1f;
        public static float CameraWidth = DefaultCameraWidth;
        public static float CameraHeight = DefaultCameraHeight;
        public readonly List<UiGameObject> UiObjects = new List<UiGameObject>();
        public readonly List<UiObject> UiButtons = new List<UiObject>();

        private static float CameraXRatio
        {
            get
            {
                return CameraWidth >= CameraHeight ? 1f : (CameraWidth / CameraHeight);
            }
        }

        private static float CameraYRatio
        {
            get
            {
                return CameraWidth > CameraHeight ? (CameraHeight / CameraWidth) : 1f;
            }
        }

        private static Vector2 ScreenRatio
        {
            get
            {
                var x = CameraXRatio * (Screen.width > Screen.height ? (Screen.height * 1f / Screen.width * 1f) : 1f);
                var y = CameraYRatio * (Screen.width >= Screen.height ? 1f : (Screen.width * 1f / Screen.height * 1f));
                if (x < 1f && y < 1f)
                {
                    if (x > y)
                    {
                        y = y / x;
                        x = 1f;
                    }
                    else
                    {
                        x = x / y;
                        y = 1f;
                    }
                }
                return new Vector2(x, y);
            }
        }

        public void RemovePopups()
        {
            var popups = UiButtons.Where(o => o.IsPopup).ToList();
            foreach (var p in popups)
            {
                p.Destroy();
                UiButtons.Remove(p);
            }
        }

        public void AddGameButton(float x, float y, Transform prefab)
        {
            var uiObject = new UiGameObject(x, y, prefab);
            UiObjects.Add(uiObject);
            ScaleObj(uiObject, CameraXRatio / DefaultCameraXRatio, CameraYRatio / DefaultCameraYRatio);
        }

        public void AddUiButton(float x, float y, Transform prefab)
        {
            AddUiButton(x, y, prefab, false);
        }

        public void AddUiButton(float x, float y, Transform prefab, bool isPopup)
        {
            var uiObject = new UiObject(x, y, prefab) {IsPopup = isPopup};
            UiButtons.Add(uiObject);
            ScaleObj(uiObject, CameraXRatio / DefaultCameraXRatio, CameraYRatio / DefaultCameraYRatio);
        }

        public void SetResolution(float x, float y)
        {
            var previousScreenHeightXRatio = ScreenRatio.x;
            var previousScreenHeightYRatio = ScreenRatio.y;
            CameraWidth = x;
            CameraHeight = y;
            _currentScaleXRatio = ScreenRatio.x / previousScreenHeightXRatio;
            _currentScaleYRatio = ScreenRatio.y / previousScreenHeightYRatio;
            MoveAndScaleObjects();
        }

        public void SaveStateAndDestroyObjects()
        {
            foreach (var obj in UiObjects)
            {
                obj.SaveStateAndDestroy();
            }
            foreach (var obj in UiButtons)
            {
                obj.SaveStateAndDestroy();
            }
        }

        public void ReCreateObjects(Transform objectPrefab)
        {
            foreach (var obj in UiObjects)
            {
                obj.ReCreate(objectPrefab);
            }
            foreach (var obj in UiButtons)
            {
                obj.ReCreate();
            }
        }

        private void SetCameraRect()
        {
            Camera.main.rect = new Rect(Margin, Margin, ScreenRatio.x * (1f - Margin * 2), ScreenRatio.y * (1f - Margin * 2));
        }

        private void MoveAndScaleObjects()
        {
            foreach (var o in UiObjects)
            {
                TransformObj(o);
                ScaleObj(o, _currentScaleXRatio, _currentScaleYRatio);
            }
            foreach (var o in UiButtons)
            {
                TransformObj(o);
                ScaleObj(o, _currentScaleXRatio, _currentScaleYRatio);
            }
        }

        private void TransformObj(UiObjectBase o)
        {
            var position = o.GameObjectTransform.transform.position;
            var destinationX = o.GameObjectTransform.transform.position.x * _currentScaleXRatio;
            var destinationY = o.GameObjectTransform.transform.position.y * _currentScaleYRatio;
            o.GameObjectTransform.Translate(destinationX - position.x, destinationY - position.y, 0f);
        }

        private void ScaleObj(UiObjectBase o, float xRatio, float yRatio)
        {
            var scale = o.GameObjectTransform.localScale;
            o.GameObjectTransform.localScale = new Vector3(scale.x * xRatio, scale.y * yRatio, scale.z);
        }
    }
}
