using _Project.Develop.Gameplay.Features.CameraFeatures;
using _Project.Develop.Gameplay.Features.DragFeatures;
using _Project.Develop.Gameplay.Features.EffectsFeatures;
using _Project.Develop.Gameplay.Features.RaycastFeatures;
using _Project.Develop.Gameplay.Features.SpawnFeatures;
using UnityEngine;

namespace _Project.Develop.Gameplay.Features.InputFeatures
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private ObjectsSpawner objectsSpawner = null;
        [SerializeField] private CameraSwitcher _cameraSwitcher = null;
        [SerializeField] private EffectSwitcher effectSwitcher = null;
        [SerializeField] private MousePointerDragging _mousePointerDragging = null;
        [SerializeField] private MouseRaycaster _mouseRaycaster = null;

        private IInputSource _input;

        private void Awake()
            => _input = new InputSystemReader();

        private void Update()
            => ReadInput();

        private void ReadInput()
        {
            if (_input.IsLeftMouseButtonWasPressed)
                _mousePointerDragging.StartDragging();

            if (_input.IsLeftMouseButtonPressed)
                _mousePointerDragging.ProcessDragging();

            if (_input.IsLeftMouseButtonWasReleased)
                _mousePointerDragging.StopDragging();

            if (_input.IsRightMouseButtonWasPressed)
                _mouseRaycaster.Shoot();

            if (_input.IsLeftArrowButtonWasPressed)
                _cameraSwitcher.PreviousCamera();

            if (_input.IsRightArrowButtonWasPressed)
                _cameraSwitcher.NextCamera();

            if (_input.IsAlpha1ButtonWasPressed)
                effectSwitcher.Choose1Effect();

            if (_input.IsAlpha2ButtonWasPressed)
                effectSwitcher.Choose2Effect();

            if (_input.IsAlpha3ButtonWasPressed)
                effectSwitcher.Choose3Effect();

            if (_input.IsAlpha4ButtonWasPressed)
                effectSwitcher.Choose4Effect();

            if (_input.IsKButtonWasPressed)
                objectsSpawner.Spawn();
        }
    }
}