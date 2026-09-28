using _Project.Develop.Gameplay.Features.CameraFeatures;
using _Project.Develop.Gameplay.Features.EffectsFeatures;
using _Project.Develop.Gameplay.Features.SpawnFeatures;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Develop.Ui.Gameplay
{
    public class UiController : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private EffectSwitcher _shooterSwitcher = null;
        [SerializeField] private CameraSwitcher _cameraSwitcher = null;
        [SerializeField] private ObjectsSpawner objectsSpawner = null;

        [Space]
        [Header("Weapon Slots:")]
        [SerializeField] private Button _weapon1Button = null;
        [SerializeField] private Button _weapon2Button = null;
        [SerializeField] private Button _weapon3Button = null;
        [SerializeField] private Button _weapon4Button = null;

        [Space]
        [Header("Cameras:")]
        [SerializeField] private Button _prevCameraButton = null;
        [SerializeField] private Button _nextCameraButton = null;

        [Space]
        [Header("Spawners:")]
        [SerializeField] private Button _spawnObjectButton = null;

        private void OnEnable()
            => Subscribe();

        private void OnDisable()
            => Unsubscribe();

        private void Subscribe()
        {
            _weapon1Button.onClick.AddListener(_shooterSwitcher.Choose1Effect);
            _weapon2Button.onClick.AddListener(_shooterSwitcher.Choose2Effect);
            _weapon3Button.onClick.AddListener(_shooterSwitcher.Choose3Effect);
            _weapon4Button.onClick.AddListener(_shooterSwitcher.Choose4Effect);

            _prevCameraButton.onClick.AddListener(_cameraSwitcher.PreviousCamera);
            _nextCameraButton.onClick.AddListener(_cameraSwitcher.NextCamera);

            _spawnObjectButton.onClick.AddListener(objectsSpawner.Spawn);
        }

        private void Unsubscribe()
        {
            _weapon1Button.onClick.RemoveListener(_shooterSwitcher.Choose1Effect);
            _weapon2Button.onClick.RemoveListener(_shooterSwitcher.Choose2Effect);
            _weapon3Button.onClick.RemoveListener(_shooterSwitcher.Choose3Effect);
            _weapon4Button.onClick.RemoveListener(_shooterSwitcher.Choose4Effect);

            _prevCameraButton.onClick.RemoveListener(_cameraSwitcher.PreviousCamera);
            _nextCameraButton.onClick.RemoveListener(_cameraSwitcher.NextCamera);

            _spawnObjectButton.onClick.RemoveListener(objectsSpawner.Spawn);
        }
    }
}