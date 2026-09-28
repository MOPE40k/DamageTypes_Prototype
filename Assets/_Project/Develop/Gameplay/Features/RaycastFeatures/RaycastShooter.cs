using _Project.Develop.Gameplay.Features.EffectsFeatures;
using UnityEngine;

namespace _Project.Develop.Gameplay.Features.RaycastFeatures
{
    public class RaycastShooter : IShooter
    {
        // References
        private readonly IShootEffect _shootEffect = null;

        public RaycastShooter(IShootEffect shootEffect)
            => _shootEffect = shootEffect;

        public void Shoot(Vector3 origin, Vector3 direction)
        {
            if (Physics.Raycast(origin, direction, out RaycastHit hit))
                _shootEffect.Execute(hit.point, hit.collider);
        }
    }
}