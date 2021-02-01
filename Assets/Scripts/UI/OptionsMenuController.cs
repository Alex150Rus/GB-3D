using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{

    [SerializeField] private CanvasGroup _optionsCanvas;
    [SerializeField] private CanvasGroup _settingsCanvas;

    [SerializeField] private UnityEvent _ResumeGame;

    public void EnableOptionsCanvas(bool enabled)
    {
        Utility.SetCanvasGroupEnabled(_optionsCanvas, enabled);
        if(!enabled && _settingsCanvas.alpha == 1) Utility.SetCanvasGroupEnabled(_settingsCanvas, enabled);
    }

    public void Continue()
    {
        Utility.SetCanvasGroupEnabled(_optionsCanvas, false);
        _ResumeGame?.Invoke();
    }

    public void Settings()
    {
        Utility.SetCanvasGroupEnabled(_optionsCanvas, false);
        Utility.SetCanvasGroupEnabled(_settingsCanvas, true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {

        Utility.SetCanvasGroupEnabled(_settingsCanvas, false);
        Utility.SetCanvasGroupEnabled(_optionsCanvas, true);
    }

}
