using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private UnityEvent _GameIsPaused;
    [SerializeField] private UnityEvent _GameIsResumed;

    private bool _gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInput.OnInputEscape += PauseGame;
    }

    private void PauseGame(bool input)
    {
        if (input && !_gamePaused) { 
            Time.timeScale = 0;
            _gamePaused = true;
            _GameIsPaused?.Invoke();
        } else if(input)
        {
            _gamePaused = false;
            ResumeGame();
            _GameIsResumed?.Invoke();
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
