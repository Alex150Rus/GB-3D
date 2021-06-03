using System;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.UserInput
{
    internal sealed class PCInputHorizontal : IUserInputProxy
    {
        public event Action<float> OnAxisChange;
        public void GetAxis()
        {
            OnAxisChange?.Invoke(Input.GetAxis(NameManager.NameManager.HORIZONTAL_AXIS));
        }
    }
}