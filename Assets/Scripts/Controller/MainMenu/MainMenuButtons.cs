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

        public MainMenuButtons(Transform mainMenuView)
        {
            //сразу получить нужное
            Button[] btnMainMenu = mainMenuView.GetChild(0).GetChild(0).GetChild(1)
                .GetComponentsInChildren<Button>();
            Button[] btnSettingsMenu = mainMenuView.GetChild(1).GetChild(0).GetChild(1)
                .GetComponentsInChildren<Button>();
            Button[] btnLevelsMenu = mainMenuView.GetChild(2).GetChild(0).GetChild(1)
                .GetComponentsInChildren<Button>();

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