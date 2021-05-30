using System.Collections.Generic;
using SpaceJailRunner.Controller.Interface;

namespace SpaceJailRunner.Controller
{
    public sealed class Controllers: IInit, IExecute, IFixedExecute, ICleanUp, ILateExecute
    {
        private readonly List<IInit> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<IFixedExecute> _fixedControllers;
        private readonly List<ICleanUp> _cleanupControllers;
        private readonly List<ILateExecute> _lateControllers;

        internal Controllers()
        {
            _initializeControllers = new List<IInit>();
            _executeControllers = new List<IExecute>();
            _fixedControllers = new List<IFixedExecute>();
            _cleanupControllers = new List<ICleanUp>();
            _lateControllers = new List<ILateExecute>();
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
                _fixedControllers.Add(fixedExecuteController);
            }
            
            if (controller is ICleanUp cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }
            
            if (controller is ILateExecute lateController)
            {
                _lateControllers.Add(lateController);
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
            for (var index = 0; index < _fixedControllers.Count; ++index)
            {
                _fixedControllers[index].FixedExecute(deltaTime);
            }
        }

        public void CleanUp()
        {
            for (var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].CleanUp();
            }
        }

        public void LateExecute(float deltaTime)
        {
            for (var index = 0; index < _lateControllers.Count; ++index)
            {
                _lateControllers[index].LateExecute(deltaTime);
            }
        }
    }
}