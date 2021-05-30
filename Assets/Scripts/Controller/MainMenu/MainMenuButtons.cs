using System;
using System.Linq;
using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.MainMenu.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal sealed class MainMenuButtons: IInit, ICleanUp, IOnClick
    {
        private readonly Button[] _btn;
        public event Action<Button> OnClick;

        public MainMenuButtons(MainMenuInit mainMenuInit)
        {
            //сразу получить нужное
            Button[] btnMainMenu = mainMenuInit.GetMainMenuButtonsLayout().GetComponentsInChildren<Button>();
            Button[] btnSettingsMenu = mainMenuInit.GetSettingsMenuButtonsLayout().GetComponentsInChildren<Button>();
            Button[] btnLevelsMenu = mainMenuInit.GetMainMenuButtonsLayout().GetComponentsInChildren<Button>();

            _btn = btnMainMenu.Union(btnSettingsMenu).Union(btnLevelsMenu).ToArray();
        }

        private void InformListeners(Button btn)
        {
            OnClick?.Invoke(btn);
        }

        public void Init()
        {
            foreach (var btn in _btn)
            {
                btn.onClick.AddListener(() => InformListeners(btn));
            }
        }


        public void CleanUp()
        {
            foreach (var btn in _btn)
            {
                btn.onClick.RemoveAllListeners();
            }
        }
    }
}