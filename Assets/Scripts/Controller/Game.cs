using SpaceJailRunner.Controller.Cameras;
using SpaceJailRunner.Controller.Level;
using SpaceJailRunner.Controller.MainMenu;
using SpaceJailRunner.Controller.Player;
using SpaceJailRunner.Level;
using SpaceJailRunner.MainMenu;
using SpaceJailRunner.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceJailRunner.Controller
{
    internal sealed class Game
    {
        private readonly Controllers _controller;
        private readonly Data.Data _data;
        private readonly Camera _camera;
        
        public Game(Controllers controller, Data.Data data)
        {
            _controller = controller;
            _data = data;
            _camera = Camera.main;
            InitializeGame();
        }

        private void InitializeGame()
        {
            
            if (SceneManager.GetActiveScene().name == _data.SceneNames.GameSceneNames[0])
            {
                   Debug.Log("MainMenu");
            }
            else
            {
                
            }
            
            // LevelFactory levelFactory = new LevelFactory();
            // LevelSwitcher levelSwitcher = new LevelSwitcher(levelFactory);
            //
            // #region Player
            //
            // PlayerFactory playerFactory = new PlayerFactory();
            // PlayerInit playerInit = new PlayerInit(playerFactory);
            //
            // #endregion
            //
            //
            // #region MainMenu
            //
            // MainMenuFactory mainMenueFactory = new MainMenuFactory();
            // MainMenuInit mainMenuInit = new MainMenuInit(mainMenueFactory);
            //
            // #region SceneLoader
            //
            // SceneLoader sceneLoader = new SceneLoader(levelSwitcher, mainMenuInit.GetMainMenuView(), playerInit, _data);
            // _controller.Add(sceneLoader);
            // #endregion
            //
            // PlayerFollowingCamera playerFollowingCamera = new PlayerFollowingCamera(_camera, playerInit.GetPlayer());
            // _controller.Add(playerFollowingCamera);
            //
            // MainMenuButtons mainMenuButtonsController = new MainMenuButtons (mainMenuInit.GetMainMenuView());
            // CanvasGroupSwitcher canvasGroupSwitcher = new CanvasGroupSwitcher(mainMenuInit.GetMainMenuView());
            // MainMenuButtonsClicked mainMenuButtonsClicked = 
            //     new MainMenuButtonsClicked(mainMenuButtonsController, 
            //         new MenuButtonsActions(canvasGroupSwitcher, sceneLoader));
            //
            // _controller.Add(mainMenuInit);
            //
            // _controller.Add(mainMenuButtonsController);
            // _controller.Add(mainMenuButtonsClicked);
            // #endregion

        }
    }
}