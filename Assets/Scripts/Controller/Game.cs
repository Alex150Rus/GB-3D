using SpaceJailRunner.Ammos;
using SpaceJailRunner.Controller.Cameras;
using SpaceJailRunner.Controller.Enemy;
using SpaceJailRunner.Controller.MainMenu;
using SpaceJailRunner.Controller.Move;
using SpaceJailRunner.Controller.Player;
using SpaceJailRunner.Data;
using SpaceJailRunner.Enemy;
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
                PlayerInit playerInit = new PlayerInit(playerFactory, _data.Player);
                PlayerFollowingCamera playerFollowingCamera = new PlayerFollowingCamera(_camera, 
                    playerInit.GetPlayer().transform,_data.Camera);

                var abstractEnemyFactory = new AbstractEnemyFactory();
                var enemyStartPoints = new EnemyStartPoints();
                var ammoAbstarctFactorty = new AmmoAbstractFactory();

                var enemyInit = new EnemyInit(abstractEnemyFactory, enemyStartPoints, _data.Enemy, ammoAbstarctFactorty);

                var patrollingEnemyMoveController = new PatrollingEnemyMoveController(enemyInit.GetPatrollingEnemies());

                var detector = new DetectEnemy();
                var playerDetector = new PlayerDetector(detector,playerInit.GetPlayer(),
                    enemyInit.GetListOfEnemies());

                var enemyAttack = new EnemyAttack(enemyInit.GetListOfEnemies());

                
               
                
                _controller.Add(playerFollowingCamera);
                _controller.Add(patrollingEnemyMoveController);
                _controller.Add(playerDetector);
                _controller.Add(enemyAttack);
            }

        }
    }
}