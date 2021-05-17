using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.MainMenu.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal class MainMenuInit: IInit, IReturnMainMenuView
    {
        private Transform _mainMenuView;
        
        public MainMenuInit(IMainMenuFactory mainMenuFactory)
        {
            _mainMenuView = mainMenuFactory.Create();
        }
        
        public void Init()
        {

        }

        public Transform GetMainMenuView()
        {
            return _mainMenuView;
        }
    }
}