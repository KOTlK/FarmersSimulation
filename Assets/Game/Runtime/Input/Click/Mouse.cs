using UnityEngine;
using UnityEngine.EventSystems;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.Input.Click
{
    public class Mouse : MonoBehaviour, IMouse
    {
        [SerializeField] private Camera _mainCamera;

        public bool Clicked
        {
            get
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return false;
                
                return UnityEngine.Input.GetKeyDown(KeyCode.Mouse0);
            }
        }

        public Vector2Int Position
        {
            get
            {
                var worldPosition = _mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
                return new Vector2Int((int)worldPosition.x, (int)worldPosition.y);
            }
        }
    }
}