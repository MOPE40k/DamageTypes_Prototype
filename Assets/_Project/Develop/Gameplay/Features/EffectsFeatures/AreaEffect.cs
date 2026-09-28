using UnityEngine;

namespace _Project.Develop.Gameplay.Features.EffectsFeatures
{
    public class AreaEffect : IShootEffect
    {
        // Settings
        private readonly float _radius = 0f;
        private readonly IShootEffect[] _shootEffects = null;
        private readonly ParticleSystem _particleEffect = null;

        public AreaEffect(IShootEffect[] shootEffects, float radius, ParticleSystem particleEffect = null)
        {
            _shootEffects = shootEffects;
            _radius = radius;
            _particleEffect = particleEffect;
        }

        public void Execute(Vector3 point, Collider collider)
        {
            CreateParticleEffect(point);

            ApplyEffectToArea(point);
        }

        private void CreateParticleEffect(Vector3 position)
        {
            if (_particleEffect != null)
                GameObject.Instantiate(_particleEffect, position, Quaternion.identity);
        }

        private void ApplyEffectToArea(Vector3 position)
        {
            Collider[] targets = Physics.OverlapSphere(position, _radius);

            if (targets.Length == 0)
                return;

            foreach (Collider target in targets)
                foreach (IShootEffect effect in _shootEffects)
                    effect.Execute(position, target);
        }
    }
}