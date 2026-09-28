using _Project.Develop.Gameplay.Features.HealthFeatures;
using UnityEngine;

namespace _Project.Develop.Gameplay.Features.EffectsFeatures
{
    public class DamageEffect : IShootEffect
    {
        // Settings
        private readonly float _damage = 0f;

        public DamageEffect(float damage)
            => _damage = damage;

        public void Execute(Vector3 point, Collider collider)
        {
            if (collider.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_damage);
        }
    }
}