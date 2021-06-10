using System;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.UserInput
{
    internal sealed class PCInputSpace: IUserInputKeDownProxy
    {
        public event Action<bool> OnBtnDown;
        public void GetBtnDown()
        {
            OnBtnDown?.Invoke(Input.GetKeyDown(KeyCode.Space));
        }
    }
}