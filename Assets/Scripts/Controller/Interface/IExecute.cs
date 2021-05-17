using UnityEngine;

namespace SpaceJailRunner.Controller.Interface
{
    internal interface IExecute : IController
    {
        void Execute(float deltaTime);
    }
}