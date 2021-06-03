using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Jump.Interface;
using SpaceJailRunner.UserInput.Interface;

namespace SpaceJailRunner.Controller.Player
{
    internal class PlayerJump: IExecute
    {
        private IJump _jumper;
        private IUserInputKeDownProxy _jumpInput;
        public PlayerJump(IJump jumper, IUserInputKeDownProxy jumpInput)
        {
            _jumper = jumper;
            _jumpInput = jumpInput;
        }

        public void Execute(float deltaTime)
        {
            _jumpInput.GetBtnDown();
        }
    }
}