using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _mine; // Наша мина
    [SerializeField] private Transform _mineSpawnPlace; // точка, где создается мина
    [SerializeField] private int _qtyOfMines = 3;

    private bool _setMine = false;

    private void Start()
    {
        _mineSpawnPlace = transform;
        PlayerInput.OnInputFireBtn += SetMine;
    }

    private void Update()
    {
        // Если нажата кнопка  
        if (_setMine)
        {
            if (_qtyOfMines > 0) {
                _qtyOfMines--;
                //операция не самая лёгкая. Нужно использовать пулл объектов
                // Создаем _mine в точке _mineSpawnPlace
                Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
            }
        }
    }

    private void SetMine(bool mine)
    {
        _setMine = mine && _qtyOfMines > 0;
    }

}
