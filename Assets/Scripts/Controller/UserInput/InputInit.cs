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
        private IUserInputKeDownProxyKeyCode  _pcKey1;
        private IUserInputKeDownProxyKeyCode  _pcKey2;

        public InputInit()
        {
            if (UnityEngine.Application.platform == RuntimePlatform.Android)
                throw new NotImplementedException("Please, create controls for Android platform");
            
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputSpace = new PCInputSpace();
            _pcInputFire = new PCInputFire();
            _pcKey1 = new PCInput1();
            _pcKey2 = new PCInput2();

        }


        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetInput()
        {
            (IUserInputProxy _inputHorizontal, IUserInputProxy _inputVertical) result =
                (_pcInputHorizontal, _pcInputVertical);
            return result;
        }

        public IUserInputKeDownProxy GetFireBtnInput()
        {
            return _pcInputFire;
        }

        public IUserInputKeDownProxy GetSpaceInput()
        {
            return _pcInputSpace;
        }
        
        public (IUserInputKeDownProxyKeyCode  key1, IUserInputKeDownProxyKeyCode  key2) GetNumbersInput()
        {
            (IUserInputKeDownProxyKeyCode  _key1, IUserInputKeDownProxyKeyCode  _key2) result = (_pcKey1, _pcKey2);
            return result;
        }
    }
}