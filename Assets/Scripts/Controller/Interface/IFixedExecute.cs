namespace SpaceJailRunner.Controller.Interface
{
    internal interface IFixedExecute : IController
    {
        void FixedExecute(float deltaTime);
    }
}