namespace SpaceJailRunner.Controller.Interface
{
    internal interface ILateExecute : IController
    {
        public void LateExecute(float deltaTime);
    }
}