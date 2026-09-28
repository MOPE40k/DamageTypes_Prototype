using UnityEngine;

namespace _Project.Develop.Gameplay.Features.EffectsFeatures
{
    public class ForceEffect : IShootEffect
    {
        // Consts
        private const ForceMode ForceModeType = ForceMode.Impulse;
        private readonly Vector3 UpwardVector = Vector3.up;

        // Settings
        private readonly float _force = default;

        public ForceEffect(float force)
            => _force = force;

        public void Execute(Vector3 point, Collider collider)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody))
            {
                Vector3 direction = (collider.bounds.center - point).normalized;

                rigidbody.AddForceAtPosition(direction * _force, point, ForceModeType);
            }
        }
    }
}