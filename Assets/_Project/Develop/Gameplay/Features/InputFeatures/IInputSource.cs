using UnityEngine;

namespace _Project.Develop.Gameplay.Features.InputFeatures
{
    public interface IInputSource
    {
        bool IsLeftMouseButtonWasPressed { get; }
        bool IsLeftMouseButtonPressed { get; }
        bool IsLeftMouseButtonWasReleased { get; }
        bool IsRightMouseButtonWasPressed { get; }
        bool IsLeftArrowButtonWasPressed { get; }
        bool IsRightArrowButtonWasPressed { get; }
        bool IsAlpha1ButtonWasPressed {get; }
        bool IsAlpha2ButtonWasPressed {get; }
        bool IsAlpha3ButtonWasPressed {get; }
        bool IsAlpha4ButtonWasPressed {get; }
        bool IsSpaceButtonReleased { get; }
        bool IsFButtonReleased { get; }
        bool IsKButtonWasPressed { get; }
        Vector3 MoveAxes { get; }
    }
}