using UnityEngine;

namespace _Project.Develop.Gameplay.Features.DragFeatures
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyDragging : MonoBehaviour, IDraggable
    {
        // References
        private Rigidbody _rigidbody = null;

        private void Awake()
            => _rigidbody = GetComponent<Rigidbody>();

        public void StartDragging()
        {
            _rigidbody.isKinematic = true;
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        public void ProcessDragging(Vector3 position)
        {
            position.y = _rigidbody.position.y;

            _rigidbody.MovePosition(position);
        }

        public void StopDragging()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}