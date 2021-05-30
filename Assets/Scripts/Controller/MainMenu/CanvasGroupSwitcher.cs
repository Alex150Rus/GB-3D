using SpaceJailRunner.Controller.MainMenu;
using SpaceJailRunner.Controller.MainMenu.Interface;
using UnityEngine;
using Screen = SpaceJailRunner.Controller.MainMenu.Screen;

namespace SpaceJailRunner.Controller.MainMenu
{
    internal sealed class CanvasGroupSwitcher : ISetScreen

    {
    private readonly CanvasGroup _mainMenu;
    private readonly CanvasGroup _settings;
    private readonly CanvasGroup _levels;

    public CanvasGroupSwitcher(MainMenuInit menuInit)
    {
        _mainMenu = menuInit.GetMainMenu().GetComponent<CanvasGroup>();
        _settings = menuInit.GetSettingsMenu().GetComponent<CanvasGroup>();
        _levels = menuInit.GetLevelMenu().GetComponent<CanvasGroup>();
        SetCurrentScreen(Screen.Main);

    }

    public void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(_mainMenu, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(_settings, screen == Screen.Settings);
        Utility.SetCanvasGroupEnabled(_levels, screen == Screen.Levels);
    }
    }
}