using SpaceJailRunner.Controller.Interface;
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
            
        }
    }
}