using System;
using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.HUD;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.HUD
{
    internal class Panels: IInit, IExecute
    {
        private IUserInputKeDownProxyKeyCode _key1;
        private IUserInputKeDownProxyKeyCode _key2;

        private PanelOne _panelOne;
        private PanelTwo _panelTwo;

        private BaseUI  _currentWindow;
        
        public Panels((IUserInputKeDownProxyKeyCode key1, IUserInputKeDownProxyKeyCode  key2) input)
        {
            input.key1.OnBtnDown += Execute;
            input.key2.OnBtnDown += Execute;
            _key1 = input.key1;
            _key2 = input.key2;
        }

        private void Execute(bool keyPressed,KeyCode keyCode)
        {
            if (keyPressed)
            {
                if (_currentWindow != null)
                {
                    _currentWindow.Cancel();
                }
                
                switch (keyCode)
                {
                    case KeyCode.Alpha1:
                        if (_currentWindow == _panelOne)
                        {
                            _panelOne.Cancel();
                            _currentWindow = null;
                        } else _currentWindow = _panelOne;
                        break;
                    case KeyCode.Alpha2:
                        if (_currentWindow == _panelTwo)
                        {
                            _panelTwo.Cancel();
                            _currentWindow = null;
                        } else _currentWindow =_panelTwo;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                _currentWindow.Execute();

            }
        }
        
        public void Init()
        {
            _panelOne = GameObject.Find("PanelOne")?.GetComponent<PanelOne>();
            _panelTwo = GameObject.Find("PanelTwo").GetComponent<PanelTwo>();
            
            _panelOne.Cancel();
            _panelTwo.Cancel();
        }

        public void Execute(float deltaTime)
        {
            _key1.GetBtnDown();
            _key2.GetBtnDown();
        }
    }
}