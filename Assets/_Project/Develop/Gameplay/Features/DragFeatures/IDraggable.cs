using UnityEngine;

namespace _Project.Develop.Gameplay.Features.DragFeatures
{
    public interface IDraggable
    {
        void StartDragging();
        void ProcessDragging(Vector3 position);
        void StopDragging();
    }
}