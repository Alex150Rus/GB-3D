using SpaceJailRunner.UserInput.Interface;

namespace SpaceJailRunner.Controller.UserInput.Interface
{
    internal interface IReturnInput
    {
        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetInput();
    }
}