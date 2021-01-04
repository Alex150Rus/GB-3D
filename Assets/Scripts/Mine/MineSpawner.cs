using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _mine; // Наша мина
    [SerializeField] private Transform _mineSpawnPlace; // точка, где создается мина

    private int qtyOfMines = 3;

    private void Update()
    {
        // Если нажата кнопка  
        if (Input.GetButtonDown("Fire1"))
        {
            if (qtyOfMines > 0) {
                qtyOfMines--;
                // Создаем _mine в точке _mineSpawnPlace
                Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
            }
        }
    }

}
