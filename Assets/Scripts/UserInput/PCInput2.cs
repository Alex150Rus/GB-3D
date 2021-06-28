using System;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.UserInput
{
    public class PCInput2: IUserInputKeDownProxyKeyCode 
    {
        public event Action<bool, KeyCode> OnBtnDown;
        public void GetBtnDown()
        {
            OnBtnDown?.Invoke(Input.GetKeyDown(KeyCode.Alpha2), KeyCode.Alpha2);
        }
    }
}