using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace _Project.Develop.Gameplay.Features.InputFeatures
{
    public class InputSystemReader : IInputSource
    {
        // Keyboard
        private KeyControl VerticalPositive => Keyboard.current.wKey;
        private KeyControl VerticalNegative => Keyboard.current.sKey;
        private KeyControl HorizontalPositive => Keyboard.current.dKey;
        private KeyControl HorizontalNegative => Keyboard.current.aKey;
        private KeyControl LeftArrow => Keyboard.current.leftArrowKey;
        private KeyControl RightArrow => Keyboard.current.rightArrowKey;
        private KeyControl Digit1 => Keyboard.current.digit1Key;
        private KeyControl Digit2 => Keyboard.current.digit2Key;
        private KeyControl Digit3 => Keyboard.current.digit3Key;
        private KeyControl Digit4 => Keyboard.current.digit4Key;
        private KeyControl SpaceKey => Keyboard.current.spaceKey;
        private KeyControl FKey => Keyboard.current.fKey;
        private KeyControl KKey => Keyboard.current.kKey;

        // Mouse
        private ButtonControl LeftMouseButton => Mouse.current.leftButton;
        private ButtonControl RightMouseButton => Mouse.current.rightButton;

        // Runtime
        public Vector3 MoveAxes => GetAxesRaw();
        public bool IsLeftMouseButtonWasPressed => LeftMouseButton.wasPressedThisFrame;
        public bool IsLeftMouseButtonPressed => LeftMouseButton.isPressed;
        public bool IsLeftMouseButtonWasReleased => LeftMouseButton.wasReleasedThisFrame;
        public bool IsRightMouseButtonWasPressed => RightMouseButton.wasPressedThisFrame;
        public bool IsLeftArrowButtonWasPressed => LeftArrow.wasPressedThisFrame;
        public bool IsRightArrowButtonWasPressed => RightArrow.wasPressedThisFrame;
        public bool IsAlpha1ButtonWasPressed => Digit1.wasPressedThisFrame;
        public bool IsAlpha2ButtonWasPressed => Digit2.wasPressedThisFrame;
        public bool IsAlpha3ButtonWasPressed => Digit3.wasPressedThisFrame;
        public bool IsAlpha4ButtonWasPressed => Digit4.wasPressedThisFrame;
        public bool IsSpaceButtonReleased => SpaceKey.wasReleasedThisFrame;
        public bool IsFButtonReleased => FKey.wasReleasedThisFrame;
        public bool IsKButtonWasPressed => KKey.wasPressedThisFrame;


        private Vector3 GetAxesRaw()
        {
            float horizontalInput = 0f;
            float verticalInput = 0f;

            if (HorizontalNegative.isPressed)
                horizontalInput = -1f;
            else if (HorizontalPositive.isPressed)
                horizontalInput = 1f;
            else
                horizontalInput = 0f;

            if (VerticalNegative.isPressed)
                verticalInput = -1f;
            else if (VerticalPositive.isPressed)
                verticalInput = 1f;
            else
                verticalInput = 0f;

            return new Vector3(horizontalInput, 0f, verticalInput);
        }
    }
}