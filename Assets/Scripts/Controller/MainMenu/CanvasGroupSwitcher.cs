using SpaceJailRunner.Controller.MainMenu;
using SpaceJailRunner.Controller.MainMenu.Interface;
using UnityEngine;
using Screen = SpaceJailRunner.Controller.MainMenu.Screen;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal class CanvasGroupSwitcher : ISetScreen

    {
    private CanvasGroup _mainMenu;
    private CanvasGroup _settings;
    private CanvasGroup _levels;

    public CanvasGroupSwitcher(Transform menuInit)
    {
        _mainMenu = menuInit.GetChild(0).GetChild(0).GetComponent<CanvasGroup>();
        _settings = menuInit.GetChild(1).GetChild(0).GetComponent<CanvasGroup>();
        _levels = menuInit.GetChild(2).GetChild(0).GetComponent<CanvasGroup>();

    }

    public void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(_mainMenu, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(_settings, screen == Screen.Settings);
        Utility.SetCanvasGroupEnabled(_levels, screen == Screen.Levels);
    }
    }
}