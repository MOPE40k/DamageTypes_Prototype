using UnityEngine;

namespace _Project.Develop.Gameplay.Features.RaycastFeatures
{
    public class MousePointerRaycaster : IRaycaster
    {
        // References
        private Camera _camera = null;

        public MousePointerRaycaster(Camera camera = null)
        {
            _camera = (camera == null)
                ? Camera.main 
                : camera;
        }
        public Ray GetRay()
            => _camera.ScreenPointToRay(Input.mousePosition);
    }
}