using System;

namespace SpaceJailRunner.UserInput.Interface
{
    internal interface IUserInputProxy
    {
        public event Action<float> OnAxisChange;
        public void GetAxis();
    }
}