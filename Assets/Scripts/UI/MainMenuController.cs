﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    enum Screen
    {
        Main,
        Settings,
    }

    public CanvasGroup mainScreen;
    public CanvasGroup settingsScreen;

    void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(mainScreen, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(settingsScreen, screen == Screen.Settings);
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

    public void OpenSettings()
    {
        SetCurrentScreen(Screen.Settings);
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
