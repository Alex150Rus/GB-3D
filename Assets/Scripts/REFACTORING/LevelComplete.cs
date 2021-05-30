using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private CanvasGroup _gameEndingCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            _gameEndingCanvas.alpha = 1;
            other.gameObject.SetActive(false);
        }
    }
}
