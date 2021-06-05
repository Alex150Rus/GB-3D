using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.UserInput.Interface;

namespace SpaceJailRunner.Controller.Player
{
    internal sealed class PlayerMove: IFixedExecute
    {
        private IMove _mover;
        private (IUserInputProxy horizontalInnput, IUserInputProxy verticalInput) _input;
        
        public PlayerMove(IMove mover, (IUserInputProxy horizontalInnput, IUserInputProxy verticalInput) input)
        {
            _mover = mover;
            _input = input;
        }
        public void FixedExecute(float deltaTime)
        {
            _input.horizontalInnput.GetAxis();
            _input.verticalInput.GetAxis();
            _mover.Move();
        }
    }
}