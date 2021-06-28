using System;
using UnityEngine;

namespace SpaceJailRunner.UserInput.Interface
{
    public interface IUserInputKeDownProxyKeyCode
    {
        public event Action<bool, KeyCode> OnBtnDown;
        public void GetBtnDown();
    }
}