using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.MainMenu.Interface;
using SpaceJailRunner.MainMenu.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal sealed class MainMenuInit: IInit, IReturnMainMenuView, IReturnLevelMenu, IReturnMainMenu, 
        IReturnSettingsMenu, IReturnLevelMenuButtonsLayout, IReturnMainMenuButtonsLayout, IReturnSettingsMenuButtonsLayout
    {
        private readonly Transform _mainMenuView;
        private Transform _mainMenu;
        private Transform _levelMenu;
        private Transform _settingsMenu;
        
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
            return _levelMenu =_mainMenuView.GetChild(2).GetChild(0);
        }

        public Transform GetMainMenu()
        {
            return _mainMenu = _mainMenuView.GetChild(0).GetChild(0);
        }

        public Transform GetSettingsMenu()
        {
            return _settingsMenu = _mainMenuView.GetChild(1).GetChild(0);
        }

        public Transform GetLevelMenuButtonsLayout()
        {
            return _levelMenu.GetChild(1);
        }

        public Transform GetMainMenuButtonsLayout()
        {
            return _mainMenu.GetChild(1);
        }

        public Transform GetSettingsMenuButtonsLayout()
        {
            return _settingsMenu.GetChild(1);
        }
    }
}