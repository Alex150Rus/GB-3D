using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Level;
using SpaceJailRunner.Controller.MainMenu;
using SpaceJailRunner.Controller.Player;
using SpaceJailRunner.Data;
using SpaceJailRunner.Level;
using UnityEngine;

namespace SpaceJailRunner.Controller.Scene
{
    internal sealed class SceneLoader: ISceneLoad, IInit
    {
        private readonly LevelSwitcher _levelSwitcher;
        private readonly MainMenuInit _mainMenuInit;
        private readonly PlayerInit _playerInit;
        private readonly Data.Data _data;
        private Transform _player;
        
        
        public SceneLoader(LevelSwitcher levelSwitcher, MainMenuInit mainMenuInit, PlayerInit playerInit, Data.Data data)
        {
            _levelSwitcher = levelSwitcher;
            _mainMenuInit = mainMenuInit;
            _playerInit = playerInit;
            _data = data;
        }
        
        public void LoadScene(int sceneNumber)
        {
            switch (sceneNumber)
            {
                case 0:
                    if(_player)
                        Object.Destroy(_player);
                    _mainMenuInit.CreateMenu();
                    break;
                case 1:
                    LoadStandardScene(_data.Player, sceneNumber, LevelNamesManager.LEVEL1_PREFAB_NAME);
                    break;
                case 2:
                    LoadStandardScene(_data.Player, sceneNumber, LevelNamesManager.LEVEL2_PREFAB_NAME);
                    break;
            }    
        }

        private void LoadStandardScene(PlayerData playerData, int sceneNumber, string levelPrefabName)
        {
            _mainMenuInit.DestroyMenu();
            _player = _playerInit.GetPlayer(playerData, sceneNumber);
            _levelSwitcher.GetLevel(levelPrefabName);   
        }

        public void Init()
        {
            LoadScene(0);
        }
    }
}