using System;

namespace Input
{
    public interface IInput
    {
        void Enable();
        Action<InputData> OnStartJamp { get; set; }
        Action<InputData> OnEndJamp { get; set; }
        InputData Updata();
    }
}

