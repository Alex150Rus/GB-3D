using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Level;
using SpaceJailRunner.Controller.MainMenu;
using SpaceJailRunner.Controller.Player;
using SpaceJailRunner.Controller.Scene;
using SpaceJailRunner.Level;
using SpaceJailRunner.MainMenu;
using SpaceJailRunner.Player;
using UnityEngine;

namespace SpaceJailRunner.Controller
{
    internal sealed class Game
    {
        private readonly Controllers _controller;
        private readonly Data.Data _idata;
        private readonly Camera _camera;
        
        public Game(Controllers controller, Data.Data data)
        {
            _controller = controller;
            _idata = data;
            _camera = Camera.main;
            InitilizeGame();
        }

        private void InitilizeGame()
        {
            
            LevelFactory levelFactory = new LevelFactory();
            LevelSwitcher levelSwitcher = new LevelSwitcher(levelFactory);

            #region Player

            PlayerFactory playerFactory = new PlayerFactory();
            PlayerInit playerInit = new PlayerInit(playerFactory);

            _controller.Add(playerInit);

            #endregion

            #region MainMenu
            
            MainMenuFactory mainMenueFactory = new MainMenuFactory();
            MainMenuInit mainMenuInit = new MainMenuInit(mainMenueFactory);

            #region SceneLoader

            SceneLoader sceneLoader = new SceneLoader(levelSwitcher, mainMenuInit, playerInit.GetPlayer());
            _controller.Add(sceneLoader);
            #endregion

            MainMenuButtons mainMenuButtonsController = new MainMenuButtons (mainMenuInit.GetMainMenuView());
            CanvasGroupSwitcher canvasGroupSwitcher = new CanvasGroupSwitcher(mainMenuInit.GetMainMenuView());
            MainMenuButtonsClicked mainMenuButtonsClicked = 
                new MainMenuButtonsClicked(mainMenuButtonsController, 
                    new MenuButtonsActions(canvasGroupSwitcher, sceneLoader));

            _controller.Add(mainMenuInit);
            
            _controller.Add(mainMenuButtonsController);
            _controller.Add(mainMenuButtonsClicked);
            #endregion

        }
    }
}