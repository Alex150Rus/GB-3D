using System;
using UnityEngine.UI;

namespace SpaceJailRunner.Controller.MainMenu.Interface
{
    internal interface IOnClick
    {
        public event Action<Button> OnClick;
    }
}