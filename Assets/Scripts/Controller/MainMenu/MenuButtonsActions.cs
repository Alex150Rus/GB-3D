using System;
using SpaceJailRunner.Controller.MainMenu.Interface;
using SpaceJailRunner.MainMenu;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal class MenuButtonsActions : IButtonAction
    {
        private CanvasGroupSwitcher _canvasGroupSwitcher;

        public MenuButtonsActions(CanvasGroupSwitcher canvasGroupSwitcher)
        {
            _canvasGroupSwitcher = canvasGroupSwitcher;
        }
        
        public void ButtonAction(Button btn)
        {
            switch (btn.name)
            {
                case MainMenuNamesManager.START_BUTTON_NAME:
                    Debug.Log("ss");
                    break;
                case MainMenuNamesManager.LEVELMENU_BUTTON_NAME:
                    _canvasGroupSwitcher.SetCurrentScreen(Screen.Levels);
                    break;
                case MainMenuNamesManager.LEVEL_1:
                    throw new NotImplementedException();
                    break;
                case MainMenuNamesManager.LEVEL_2:
                    throw new NotImplementedException();
                    break;
                case MainMenuNamesManager.MAIN_MENU:
                    _canvasGroupSwitcher.SetCurrentScreen(Screen.Main);
                    break;
            }
        }
    }
}