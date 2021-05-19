using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Level;
using SpaceJailRunner.Controller.MainMenu;
using SpaceJailRunner.Level;
using UnityEngine;

namespace SpaceJailRunner.Controller.Scene
{
    internal class SceneLoader: ISceneLoad, IInit
    {
        private LevelSwitcher _levelSwitcher;
        private MainMenuInit _mainMenuInit;
        
        public SceneLoader(LevelSwitcher levelSwitcher, MainMenuInit mainMenuInit)
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