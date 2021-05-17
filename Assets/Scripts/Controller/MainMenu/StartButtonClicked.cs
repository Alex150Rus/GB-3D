using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal class StartButtonClicked: ICleanUp
    {
        private IOnClick _startButtonController;
        
        public StartButtonClicked(IOnClick startButtonController)
        {
            _startButtonController = startButtonController;
            _startButtonController.OnClick += DoAction;
        }

        private void DoAction()
        {
            Debug.Log("start btn clicked");
        }

        public void CleanUp()
        {
            _startButtonController.OnClick -= DoAction;
        }
    }
}