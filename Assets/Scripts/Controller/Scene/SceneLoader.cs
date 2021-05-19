using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Level;
using SpaceJailRunner.Controller.MainMenu;
using SpaceJailRunner.Level;
using UnityEngine;

namespace SpaceJailRunner.Controller.Scene
{
    internal sealed class SceneLoader: ISceneLoad, IInit
    {
        private readonly LevelSwitcher _levelSwitcher;
        private readonly MainMenuInit _mainMenuInit;
        private readonly Transform _player;
        
        
        public SceneLoader(LevelSwitcher levelSwitcher, MainMenuInit mainMenuInit, Transform player)
        {
            _levelSwitcher = levelSwitcher;
            _mainMenuInit = mainMenuInit;
        }
        
        public void LoadScene(int sceneNumber)
        {
            switch (sceneNumber)
            {
                case 0:
                    _mainMenuInit.CreateMenu();
                    break;
                case 1:
                    _mainMenuInit.DestroyMenu();
                    _levelSwitcher.GetLevel(LevelNamesManager.LEVEL1_PREFAB_NAME);   
                    break;
                case 2:
                    _mainMenuInit.DestroyMenu();
                    _levelSwitcher.GetLevel(LevelNamesManager.LEVEL2_PREFAB_NAME);
                    break;
            }    
        }

        public void Init()
        {
            LoadScene(0);
        }
    }
}