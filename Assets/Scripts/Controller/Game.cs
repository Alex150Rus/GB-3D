using SpaceJailRunner.Controller.Interface;

namespace SpaceJailRunner.Controller
{
    internal class Game
    {
        private IController _controller;
        private Data.Data _idata;
        
        public Game(IController controller, Data.Data data)
        {
            _controller = controller;
            _idata = data;
            InitilizeGame();
        }

        private void InitilizeGame()
        {
            
        }
    }
}