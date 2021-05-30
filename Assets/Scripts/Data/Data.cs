using System.IO;
using SpaceJailRunner.Data;
using UnityEngine;

namespace SpaceJailRunner.Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data", order = 0)]
    internal class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _sceneNamesDataPath;
        [SerializeField] private string _cameraDataPath;
       
        private PlayerData _player;
        private SceneNames _sceneNames;
        private CameraData _camera;
        
        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _player;
            }
        }

        public SceneNames SceneNames
        {
            get
            {
                if (_sceneNames == null)
                {
                    _sceneNames = Load<SceneNames>("Data/" + _sceneNamesDataPath);
                }

                return _sceneNames;
            }
        }
        
        public CameraData Camera
        {
            get
            {
                if (_camera == null)
                {
                    _camera = Load<CameraData>("Data/" + _cameraDataPath);
                }

                return _camera;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}