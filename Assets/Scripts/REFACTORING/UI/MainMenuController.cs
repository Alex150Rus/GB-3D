using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    enum Screen
    {
        Main,
        Settings,
        Levels,
    }

    public CanvasGroup mainScreen;
    public CanvasGroup settingsScreen;
    public CanvasGroup levelsScreen;

    void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(mainScreen, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(settingsScreen, screen == Screen.Settings);
        Utility.SetCanvasGroupEnabled(levelsScreen, screen == Screen.Levels);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCurrentScreen(Screen.Main);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void StartLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OpenSettings()
    {
        SetCurrentScreen(Screen.Settings);
    }

    public void OpenLevelMenu()
    {
        SetCurrentScreen(Screen.Levels);
    }

    public void CloseSettings()
    {
        SetCurrentScreen(Screen.Main);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
