using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputPlayer : IInput
    {
        public Action<InputData> OnMoveButton { get { return onMoveButton; } set { onMoveButton = value; } }
        private Action<InputData> onMoveButton;
        public Action<InputData> OnStartPressButton { get { return onStartPressButton; } set { onStartPressButton = value; } }
        private Action<InputData> onStartPressButton;
        public Action<InputData> OnEndPressButton { get { return onEndPressButton; } set { onEndPressButton = value; } }
        private Action<InputData> onEndPressButton;
        public Action<InputData> OnMoveMouse { get { return onMoveMouse; } set { onMoveMouse = value; } }
        private Action<InputData> onMoveMouse;
        public Action<Vector3> OnCurrentFlip { get { return onCurrentFlip; } set { onCurrentFlip = value; } }
        private Action<Vector3> onCurrentFlip;

        private InputData inputData;
        private InputActions inputActions;

        public void Enable()
        {
            inputData = new InputData();
            inputActions = new InputActions();
            if (inputActions != null)
            {
                //Карта Key
                {
                    inputActions.KeyMap.WASD.started += contex => { inputData.Move = contex.ReadValue<Vector2>(); MoveButton(inputData); };
                    inputActions.KeyMap.WASD.performed += contex => { inputData.Move = contex.ReadValue<Vector2>(); MoveButton(inputData); };
                    inputActions.KeyMap.WASD.canceled += contex => { inputData.Move = contex.ReadValue<Vector2>(); MoveButton(inputData); };

                    inputActions.KeyMap.Look.started += contex => { inputData.Mouse = contex.ReadValue<Vector2>(); inputData.MousePosition = Mouse.current.position.ReadValue(); MoveMouse(inputData);};
                    inputActions.KeyMap.Look.performed += contex => { inputData.Mouse = contex.ReadValue<Vector2>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };
                    inputActions.KeyMap.Look.canceled += contex => { inputData.Mouse = contex.ReadValue<Vector2>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };

                    inputActions.KeyMap.Jamp.started += context => { inputData.Jamp = context.ReadValue<float>(); StartPressButton(inputData); };
                    inputActions.KeyMap.Jamp.performed += context => { inputData.Jamp = context.ReadValue<float>(); };
                    inputActions.KeyMap.Jamp.canceled += context => { inputData.Jamp = context.ReadValue<float>(); EndPressButton(inputData); };
                }

                inputActions.Enable();
            }
        }
        public void OnDisable()
        {
            inputActions.Disable();
        }
        private void MoveButton(InputData _inputData)
        {
            onMoveButton?.Invoke(_inputData);
        }
        private void StartPressButton(InputData _inputData)
        {
            onStartPressButton?.Invoke(_inputData);
        }
        private void EndPressButton(InputData _inputData)
        {
            onEndPressButton?.Invoke(_inputData);
        }
        private void MoveMouse(InputData _inputData)
        {
            onMoveMouse?.Invoke(_inputData);
        }
        public void CurrentFlip(Vector3 _scale)
        {
            onCurrentFlip?.Invoke(_scale);
        }
    }
}

