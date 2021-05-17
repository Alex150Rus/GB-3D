using System.Collections.Generic;
using SpaceJailRunner.Controller.Interface;

namespace SpaceJailRunner.Controller
{
    public class Controllers: IInit, IExecute, IFixedExecute, ICleanUp
    {
        private readonly List<IInit> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<IFixedExecute> _lateControllers;
        private readonly List<ICleanUp> _cleanupControllers;

        internal Controllers()
        {
            _initializeControllers = new List<IInit>();
            _executeControllers = new List<IExecute>();
            _lateControllers = new List<IFixedExecute>();
            _cleanupControllers = new List<ICleanUp>();
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IInit initializeController)
            {
                _initializeControllers.Add(initializeController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is IFixedExecute fixedExecuteController)
            {
                _lateControllers.Add(fixedExecuteController);
            }
            
            if (controller is ICleanUp cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }
        
        public void Init()
        {
            for (var index = 0; index < _initializeControllers.Count; ++index)
            {
                _initializeControllers[index].Init();
            }
        }
        
        public void Execute(float deltaTime)
        {
            for (var index = 0; index < _executeControllers.Count; ++index)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }
        
        public void FixedExecute(float deltaTime)
        {
            for (var index = 0; index < _lateControllers.Count; ++index)
            {
                _lateControllers[index].FixedExecute(deltaTime);
            }
        }

        public void CleanUp()
        {
            for (var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].CleanUp();
            }
        }
    }
}