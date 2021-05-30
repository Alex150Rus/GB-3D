using SpaceJailRunner.Controller.Cameras;
using SpaceJailRunner.Controller.MainMenu;
using SpaceJailRunner.Controller.Player;
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
                   MainMenuFactory mainMenuFactory = new MainMenuFactory();
                   MainMenuInit mainMenuInit = new MainMenuInit(mainMenuFactory);
                   
                   MainMenuButtons mainMenuButtonsController = new MainMenuButtons (mainMenuInit);
                   CanvasGroupSwitcher canvasGroupSwitcher = new CanvasGroupSwitcher(mainMenuInit);
                   MainMenuButtonsClicked mainMenuButtonsClicked = 
                       new MainMenuButtonsClicked(mainMenuButtonsController, 
                           new MenuButtonsActions(canvasGroupSwitcher, _data.SceneNames));
                   
                   _controller.Add(mainMenuInit);
                   _controller.Add(mainMenuButtonsController);
                   _controller.Add(mainMenuButtonsClicked);
                   
            }
            else
            {
                PlayerFactory playerFactory = new PlayerFactory();
                PlayerInit playerInit = new PlayerInit(playerFactory);
                PlayerFollowingCamera playerFollowingCamera = new PlayerFollowingCamera(_camera, playerInit.GetPlayer(),
                    _data.Camera);
                _controller.Add(playerFollowingCamera);
            }

        }
    }
}