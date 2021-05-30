using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.MainMenu.Interface;
using SpaceJailRunner.MainMenu.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal sealed class MainMenuInit: IInit, IReturnMainMenuView
    {
        private Transform _mainMenuView;
        private readonly IMainMenuFactory _mainMenuFactory;
        
        public MainMenuInit(IMainMenuFactory mainMenuFactory)
        {
            _mainMenuView = mainMenuFactory.Create();
            _mainMenuFactory = mainMenuFactory;
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