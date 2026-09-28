using UnityEngine;

namespace _Project.Develop.Gameplay.Features.ParticlesFeatures
{
    public class ParticleEffectsController : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private ParticleSystem _particlePrefab = null;

        public void Play(Vector3 position)
        {
            if (_particlePrefab)
                Instantiate(_particlePrefab, position, Quaternion.identity);
        }
    }
}