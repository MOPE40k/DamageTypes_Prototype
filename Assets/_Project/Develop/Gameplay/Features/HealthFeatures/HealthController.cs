using _Project.Develop.Gameplay.Features.AnimationFeatures;
using _Project.Develop.Gameplay.Features.ParticlesFeatures;
using UnityEngine;

namespace _Project.Develop.Gameplay.Features.HealthFeatures
{
    public class HealthController : MonoBehaviour, IDamageable
    {
        [Header("Settings:")]
        [SerializeField] private float _maxHealth = 100f;

        [Space]
        [Header("References:")]
        [SerializeField] private HealthBarView _view = default;
        [SerializeField] private ParticleEffectsController _particleEffectsController = default;
        [SerializeField] private InteractObjectAnimationController _animationController = default;

        // Runtime
        private float _currentHealth = 0f;

        private void Awake()
        {
            _currentHealth = _maxHealth;

            if (_view)
            {
                _view.SetMaxHealth(_maxHealth);
                _view.Redraw(_currentHealth);
            }
        }

        public void TakeDamage(float damage)
        {
            _currentHealth = Mathf.Max(0, _currentHealth - damage);

            if (_animationController)
                _animationController.InteractableAnimation();

            if (_view)
                _view.Redraw(_currentHealth);

            if (_currentHealth <= 0f)
            {
                if (_particleEffectsController)
                    _particleEffectsController.Play(transform.position);

                Destroy(gameObject);
            }
        }
    }
}