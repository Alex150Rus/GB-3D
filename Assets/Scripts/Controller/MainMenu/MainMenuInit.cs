using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.MainMenu.Interface;
using SpaceJailRunner.MainMenu.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal sealed class MainMenuInit: IInit, IReturnMainMenuView, IReturnLevelMenu, IReturnMainMenu, 
        IReturnSettingsMenu
    {
        private readonly Transform _mainMenuView;
        
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

        public Transform GetLevelMenu()
        {
            return _mainMenuView.GetChild(2).GetChild(0);
        }

        public Transform GetMainMenu()
        {
            return _mainMenuView.GetChild(0).GetChild(0);
        }

        public Transform GetSettingsMenu()
        {
            return _mainMenuView.GetChild(1).GetChild(0);
        }
    }
}