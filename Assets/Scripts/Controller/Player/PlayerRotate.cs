using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Rotate.Interface;
using SpaceJailRunner.UserInput.Interface;

namespace SpaceJailRunner.Controller.Player
{
    internal class PlayerRotate: IFixedExecute
    { private IRotate _rotator;
        private (IUserInputProxy horizontalInnput, IUserInputProxy verticalInput) _input;
        
        public PlayerRotate(IRotate rotator, (IUserInputProxy horizontalInnput, IUserInputProxy verticalInput) input)
        {
            _rotator = rotator;
            _input = input;
        }
        public void FixedExecute(float deltaTime)
        {
            _input.horizontalInnput.GetAxis();
            _input.verticalInput.GetAxis();
            _rotator.Rotate();
        }
    }
}