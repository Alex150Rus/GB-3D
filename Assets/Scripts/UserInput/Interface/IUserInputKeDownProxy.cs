using System;

namespace SpaceJailRunner.UserInput.Interface
{
    internal interface IUserInputKeDownProxy
    {
        public event Action<bool> OnBtnDown;
        public void GetBtnDown();
    }
}