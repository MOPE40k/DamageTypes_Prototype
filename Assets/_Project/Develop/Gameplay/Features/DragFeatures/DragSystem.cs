using UnityEngine;

namespace _Project.Develop.Gameplay.Features.DragFeatures
{
    public class DragSystem
    {
        // Consts
        private const float RaycastMaxDistance = 100f;

        // Settings
        private readonly LayerMask _surfaceLayer = 0;
        private readonly LayerMask _targetLayer = 0;

        // Runtime
        private IDraggable _currentDraggable = null;

        public DragSystem(LayerMask surfaceLayer, LayerMask targetLayer)
        {
            _surfaceLayer = surfaceLayer;
            _targetLayer = targetLayer;
        }

        public void StartDragging(Vector3 origin, Vector3 direction)
        {
            if (_currentDraggable != null)
                return;

            if (Physics.Raycast(origin, direction, out RaycastHit hit, RaycastMaxDistance, _targetLayer))
            {
                if (hit.collider.TryGetComponent(out IDraggable draggable))
                {
                    _currentDraggable = draggable;
                    _currentDraggable.StartDragging();
                }
            }
        }

        public void ProcessDragging(Vector3 origin, Vector3 direction)
        {
            if (_currentDraggable == null)
                return;

            if (Physics.Raycast(origin, direction, out RaycastHit hit, RaycastMaxDistance, _surfaceLayer))
                _currentDraggable.ProcessDragging(hit.point);
        }

        public void StopDragging()
        {
            if (_currentDraggable == null)
                return;

            _currentDraggable.StopDragging();
            _currentDraggable = null;
        }
    }
}