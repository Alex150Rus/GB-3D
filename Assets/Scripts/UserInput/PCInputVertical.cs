using System;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.UserInput
{
    internal sealed class PCInputVertical : IUserInputProxy
    {
        public event Action<float> OnAxisChange;
        public void GetAxis()
        {
            OnAxisChange?.Invoke(Input.GetAxis(NameManager.NameManager.VERTICAL_AXIS));
        }
    }
}