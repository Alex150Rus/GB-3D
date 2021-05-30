using System;
using SpaceJailRunner.Controller.MainMenu.Interface;
using SpaceJailRunner.MainMenu;
using SpaceJailRunner.Data;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal sealed class MenuButtonsActions : IButtonAction
    {
        private readonly CanvasGroupSwitcher _canvasGroupSwitcher;
        private readonly SceneNames _sceneNames;

        public MenuButtonsActions(CanvasGroupSwitcher canvasGroupSwitcher, SceneNames sceneNames)
        {
            _canvasGroupSwitcher = canvasGroupSwitcher;
            _sceneNames = sceneNames;
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
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void StartBtnAction()
        {
            SceneManager.LoadScene(_sceneNames.GameSceneNames[1]);
        }

        private void LevelBtnAction()
        {
            _canvasGroupSwitcher.SetCurrentScreen(Screen.Levels);
        }

        private void LevelChoosingBtnAction(int levelNumber)
        {
            SceneManager.LoadScene(_sceneNames.GameSceneNames[levelNumber]);
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