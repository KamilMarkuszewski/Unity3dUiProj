using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ButtonsScripts
{
    public class DragScript : MonoBehaviour
    {
        private readonly Color _mouseOverColor = Color.grey;
        private readonly Color _originalColor = Color.white;
        private bool _dragging;
        private float _distance;
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void OnMouseEnter()
        {
            if (_renderer != null)
            {
                _renderer.material.color = _mouseOverColor;
            }

        }

        private void OnMouseExit()
        {
            if (_renderer != null)
            {
                _renderer.material.color = _originalColor;
            }
        }

        private void OnMouseDown()
        {
            //przesuwac mozna tylko w trybie edycji
            if (!GameController.IsStarted && !GameController.IsInitialized)
            {
                _distance = Vector3.Distance(transform.position, Camera.main.transform.position);
                _dragging = true;
            }
        }

        private void OnMouseUp()
        {
            _dragging = false;
        }

        private void Update()
        {
            if (_dragging)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var rayPoint = ray.GetPoint(_distance);
                transform.position = rayPoint;
            }
        }
    }
}
