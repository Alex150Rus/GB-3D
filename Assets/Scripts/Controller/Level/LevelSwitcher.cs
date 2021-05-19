using SpaceJailRunner.Level;
using UnityEngine;

namespace SpaceJailRunner.Controller.Level
{
    internal sealed class LevelSwitcher: IGetLevel
    {
        private readonly LevelFactory _levelFactory;
        private Transform _loadedLevel;
        
        public LevelSwitcher(LevelFactory levelFactory)
        {
            _levelFactory = levelFactory;
        }
        
        public Transform GetLevel(string levelName)
        {
            if (!_loadedLevel)
                return _loadedLevel = _levelFactory.CreateLevel(levelName);

            if (_loadedLevel.name == $"{levelName}(Clone)")
                return _loadedLevel;
            
            Object.Destroy(_loadedLevel);
            return _loadedLevel = _levelFactory.CreateLevel(levelName);
        }
    }
}