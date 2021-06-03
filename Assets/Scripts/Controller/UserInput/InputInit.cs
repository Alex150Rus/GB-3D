using System;
using SpaceJailRunner.Controller.UserInput.Interface;
using SpaceJailRunner.UserInput;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.UserInput
{
    internal sealed class InputInit: IReturnInput, IReturnFireBtnInput, IReturnSpaceInput
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserInputKeDownProxy _pcInputSpace;
        private IUserInputKeDownProxy _pcInputFire;

        public InputInit()
        {
            if (UnityEngine.Application.platform == RuntimePlatform.Android)
                throw new NotImplementedException("Please, create controls for Android platform");
            
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputSpace = new PCInputSpace();
            _pcInputFire = new PCInputFire();
        }


        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetInput()
        {
            (IUserInputProxy _inputHorizontal, IUserInputProxy _inputVertical) result =
                (_pcInputHorizontal, _pcInputVertical);
            return result;
        }

        public IUserInputKeDownProxy GetFireBtnInput()
        {
            return _pcInputSpace;
        }

        public IUserInputKeDownProxy GetSpaceInput()
        {
            return _pcInputFire;
        }
    }
}