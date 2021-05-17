using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.MainMenu;
using SpaceJailRunner.MainMenu;
using UnityEngine;

namespace SpaceJailRunner.Controller
{
    internal class Game
    {
        private Controllers _controller;
        private Data.Data _idata;
        private Camera _camera;
        
        public Game(Controllers controller, Data.Data data)
        {
            _controller = controller;
            _idata = data;
            _camera = Camera.main;
            InitilizeGame();
        }

        private void InitilizeGame()
        {
            MainMenuFactory mainMenueFactory = new MainMenuFactory();
            MainMenuInit mainMenuInit = new MainMenuInit(mainMenueFactory);

            MainMenuButtons mainMenuButtonsController = new MainMenuButtons (mainMenuInit.GetMainMenuView());
            MainMenuButtonsClicked mainMenuButtonsClicked = 
                new MainMenuButtonsClicked(mainMenuButtonsController, 
                    new MenuButtonsActions(new CanvasGroupSwitcher(mainMenuInit.GetMainMenuView())));

            _controller.Add(mainMenuInit);
            
            _controller.Add(mainMenuButtonsController);
            _controller.Add(mainMenuButtonsClicked);
            
        }
    }
}