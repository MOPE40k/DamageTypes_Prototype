using _Project.Develop.Gameplay.Features.RaycastFeatures;
using UnityEngine;

namespace _Project.Develop.Gameplay.Features.EffectsFeatures
{
    public class EffectSwitcher : MonoBehaviour
    {
        [Header("Damage Effect Settings:")]
        [SerializeField] private float _damage = 10f;

        [Space]
        [Header("Force Effect Settings:")]
        [SerializeField] private float _force = 10f;

        [Space]
        [Header("Area of Effect Settings:")]
        [SerializeField] private float _areaRadius = 5f;

        [Space]
        [Header("References:")]
        [SerializeField] private MouseRaycaster _raycaster = null;
        [SerializeField] private ParticleSystem _explosionParticle = null;
        [SerializeField] private ParticleSystem _forceParticle = null;

        private void Awake()
            => _raycaster.SetShooter(new RaycastShooter(new DamageEffect(_damage)));

        public void Choose1Effect()
            => ChooseEffect(1);

        public void Choose2Effect()
            => ChooseEffect(2);

        public void Choose3Effect()
            => ChooseEffect(3);

        public void Choose4Effect()
            => ChooseEffect(4);

        private void ChooseEffect(int effectIndex)
        {
            _raycaster.SetShooter(effectIndex switch
            {
                1 => new RaycastShooter(new DamageEffect(_damage)),

                2 => new RaycastShooter(new AreaEffect(
                    new IShootEffect[] { new DamageEffect(_damage), new ForceEffect(_force) },
                    _areaRadius,
                    _explosionParticle)),

                3 => new RaycastShooter(new ForceEffect(_force)),

                4 => new RaycastShooter(new AreaEffect(
                    new IShootEffect[] { new ForceEffect(_force) },
                    _areaRadius,
                    _forceParticle)),

                _ => new RaycastShooter(new DamageEffect(_damage))
            });
        }
    }
}