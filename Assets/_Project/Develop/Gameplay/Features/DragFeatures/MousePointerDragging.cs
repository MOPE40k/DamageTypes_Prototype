using _Project.Develop.Gameplay.Features.RaycastFeatures;
using UnityEngine;

namespace _Project.Develop.Gameplay.Features.DragFeatures
{
    public class MousePointerDragging : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField] private LayerMask _surfaceLayer = 0;
        [SerializeField] private LayerMask _targetLayer = 0;

        // References
        private IRaycaster _raycaster = null;
        private DragSystem _dragSystem = null;

        // Runtime
        Ray _ray => _raycaster.GetRay();

        private void Awake()
        {
            _raycaster = new MousePointerRaycaster();
            _dragSystem = new DragSystem(_surfaceLayer, _targetLayer);
        }

        public void StartDragging()
            => _dragSystem.StartDragging(_ray.origin, _ray.direction);

        public void ProcessDragging()
            => _dragSystem.ProcessDragging(_ray.origin, _ray.direction);

        public void StopDragging()
            => _dragSystem.StopDragging();
    }
}