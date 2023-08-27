using System.Collections;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class UIItemsMover : MonoBehaviour
    {
        [SerializeField] private float _sensitivity;
        [SerializeField] private RectTransform _movable;
        [SerializeField] private Vector2 _minMax;
        private Coroutine _input;
        
        
        private IEnumerator InputTaking()
        {
            var pos = Input.mousePosition;
            var prevPos = Input.mousePosition;
            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pos = Input.mousePosition;
                    prevPos = Input.mousePosition;
                }

                if (Input.GetMouseButton(0))
                {
                    var diff = pos - prevPos;
                    
                }

                prevPos = pos;
                yield return null;
            }
        }
        
        
    }
}