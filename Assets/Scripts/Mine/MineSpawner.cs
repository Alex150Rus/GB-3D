using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _mine; // Наша мина
    [SerializeField] private Transform _mineSpawnPlace; // точка, где создается мина
    [SerializeField] private Inventory _inventory;

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
            if (_inventory.MinesQty > 0) {
                //операция не самая лёгкая. Нужно использовать пулл объектов
                // Создаем _mine в точке _mineSpawnPlace
                Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
                _inventory.MinesQty--;
            }
        }
    }

    private void SetMine(bool mine)
    {
        _setMine = mine && _inventory.MinesQty > 0;
    }

}
