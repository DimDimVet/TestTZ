using System;

namespace Input
{
    public interface IInput
    {
        void Enable();
        //InputData Updata();
        Action<InputData> OnMoveButton { get; set; }
        Action<InputData> OnStartPressButton { get; set; }
        Action<InputData> OnEndPressButton { get; set; }
        Action<InputData> OnMoveMouse { get; set; }
    }
}

