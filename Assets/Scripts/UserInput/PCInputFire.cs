using System;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.UserInput
{
    internal sealed class PCInputFire: IUserInputKeDownProxy
    {
        public event Action<bool> OnBtnDown;
        public void GetBtnDown()
        {
            OnBtnDown?.Invoke(Input.GetButtonDown(NameManager.NameManager.FIRE_BUTTON));
        }
    }
}