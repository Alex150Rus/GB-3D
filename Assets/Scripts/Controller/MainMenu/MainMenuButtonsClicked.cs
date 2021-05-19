using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.MainMenu.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal sealed class MainMenuButtonsClicked: ICleanUp
    {
        private readonly IOnClick _mainMenuButtonsController;
        private readonly IButtonAction _buttonActions;
        
        public  MainMenuButtonsClicked(IOnClick mainMenuButtonsController, IButtonAction buttonActions)
        {
            _mainMenuButtonsController = mainMenuButtonsController;
            _buttonActions = buttonActions;
            _mainMenuButtonsController.OnClick += DoAction;
        }

        private void DoAction(Button btn)
        {
            _buttonActions.ButtonAction(btn);
        }

        public void CleanUp()
        {
            _mainMenuButtonsController.OnClick -= DoAction;
        }
    }
}