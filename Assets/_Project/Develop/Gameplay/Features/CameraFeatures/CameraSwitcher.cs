using Cinemachine;
using UnityEngine;

namespace _Project.Develop.Gameplay.Features.CameraFeatures
{
    public class CameraSwitcher : MonoBehaviour
    {
        private const int StartingCameraIndex = 0;
        
        [Header("Cameras:")]
        [SerializeField] private CinemachineVirtualCamera[] _cameras = null;

        // Runtime
        private int _currentCameraIndex = default;

        private void Awake()
            => SetCurrentCamera(StartingCameraIndex);

        public void NextCamera()
        {
            _currentCameraIndex = (_currentCameraIndex + 1) % _cameras.Length;

            SetCurrentCamera(_currentCameraIndex);
        }

        public void PreviousCamera()
        {
            _currentCameraIndex = (_currentCameraIndex - 1 + _cameras.Length) % _cameras.Length;

            SetCurrentCamera(_currentCameraIndex);
        }

        private void SetCurrentCamera(int cameraIndex)
        {
            foreach (CinemachineVirtualCamera camera in _cameras)
                camera.gameObject.SetActive(false);

            _cameras[cameraIndex].gameObject.SetActive(true);
        }
    }
}