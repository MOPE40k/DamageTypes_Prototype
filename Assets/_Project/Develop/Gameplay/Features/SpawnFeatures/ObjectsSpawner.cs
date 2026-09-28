using _Project.Develop.Gameplay.Features.DragFeatures;
using UnityEngine;

namespace _Project.Develop.Gameplay.Features.SpawnFeatures
{
    public class ObjectsSpawner : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField, Min(0.1f)] private float _spawnAreaRadius = 5f;

        [Space]
        [Header("References:")]
        [SerializeField] private RigidbodyDragging[] _objectPrefabs = null;
        [SerializeField] private Transform _spawnPoint = null;

#if UNITY_EDITOR
        [Space]
        [Header("ON DRAW GIZMOS SETTINGS:")]
        [SerializeField] private Color _gizmosColor = Color.green;
#endif

        public void Spawn()
        {
            var randomIndex = Random.Range(0, _objectPrefabs.Length);
            var randomPrefab = _objectPrefabs[randomIndex];
            
            var randomPosition = Random.insideUnitSphere * _spawnAreaRadius;
            randomPosition.y = _spawnPoint.position.y;

            Instantiate(randomPrefab, randomPosition, Quaternion.identity);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawWireSphere(_spawnPoint.position, _spawnAreaRadius);
        }
#endif
    }
}