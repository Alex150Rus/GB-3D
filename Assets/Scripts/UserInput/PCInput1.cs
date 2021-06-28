using System;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.UserInput
{
    public class PCInput1: IUserInputKeDownProxyKeyCode
    {
        public event Action<bool, KeyCode> OnBtnDown;
        public void GetBtnDown()
        {
            OnBtnDown?.Invoke(Input.GetKeyDown(KeyCode.Alpha1), KeyCode.Alpha1);
        }
    }
}