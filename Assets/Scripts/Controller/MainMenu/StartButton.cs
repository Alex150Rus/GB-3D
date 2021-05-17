using System;
using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Interface;
using SpaceJailRunner.MainMenu;
using SpaceJailRunner.MainMenu.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal class StartButton: IInit, ICleanUp, IOnClick
    {
        private Button _btn;
        public event Action OnClick;

        public StartButton(Transform mainMenuView)
        {
            _btn = mainMenuView.GetChild(0).GetChild(0).GetChild(1)
                .Find(MainMenuNamesManager.START_BUTTON_NAME).GetComponent<Button>();
        }

        private void InformListeners()
        {
            OnClick?.Invoke();
        }

        public void Init()
        {
            _btn.onClick.AddListener(InformListeners);
        }


        public void CleanUp()
        {
            _btn.onClick.RemoveListener(InformListeners);
        }
    }
}