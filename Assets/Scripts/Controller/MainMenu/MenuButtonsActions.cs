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
                    StartBtnAction();
                    break;
                case MainMenuNamesManager.LEVELMENU_BUTTON_NAME:
                    LevelBtnAction();
                    break;
                case MainMenuNamesManager.LEVEL_1:
                    LevelChoosingBtnAction(1);
                    break;
                case MainMenuNamesManager.LEVEL_2:
                    LevelChoosingBtnAction(2);
                    break;
                case MainMenuNamesManager.MAIN_MENU:
                    MainMenuBtnAction();
                    break;
                case MainMenuNamesManager.SETTINGS:
                    SettingsBtnAction();
                    break;
                case MainMenuNamesManager.EXIT:
                    ExitBtnAction();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("missing button name or wrong name");
            }
        }

        private void StartBtnAction()
        {
            Debug.Log("ss");
        }

        private void LevelBtnAction()
        {
            _canvasGroupSwitcher.SetCurrentScreen(Screen.Levels);
        }

        private void LevelChoosingBtnAction(int levelNumber)
        {
            throw new NotImplementedException();
        }

        private void MainMenuBtnAction()
        {
            _canvasGroupSwitcher.SetCurrentScreen(Screen.Main);   
        }

        private void SettingsBtnAction()
        {
            _canvasGroupSwitcher.SetCurrentScreen(Screen.Settings);
        }

        private void ExitBtnAction()
        {
            throw new NotImplementedException();
        }
    }
}