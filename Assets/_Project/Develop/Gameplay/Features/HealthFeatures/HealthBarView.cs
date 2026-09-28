using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Develop.Gameplay.Features.HealthFeatures
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private SpriteHealthBar _healthBar = null;

        private float _maxHealth = 0f;
        private Camera _cameraMain = default;

        private void Start()
            => _cameraMain = Camera.main;

        private void LateUpdate()
            => _healthBar.transform.rotation = _cameraMain.transform.rotation;

        public void SetMaxHealth(float maxHealth)
            => _maxHealth = maxHealth;

        public void Redraw(float currentHealth)
            => _healthBar.SetHealth(currentHealth, _maxHealth);
    }
}