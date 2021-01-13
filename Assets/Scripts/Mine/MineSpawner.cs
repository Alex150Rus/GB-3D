using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{

    [SerializeField] private GameObject mine; // Наша мина
    [SerializeField] private Transform mineSpawnPlace; // точка, где создается мина
    [SerializeField] private int qtyOfMines = 3;

    private bool _setMine = false;

    private void Start()
    {
        PlayerInput.OnInputFireBtn += SetMine;
    }

    private void Update()
    {
        // Если нажата кнопка  
        if (_setMine)
        {
            if (qtyOfMines > 0) {
                qtyOfMines--;
                // Создаем _mine в точке _mineSpawnPlace
                Instantiate(mine, mineSpawnPlace.position, mineSpawnPlace.rotation);
            }
        }
    }

    private void SetMine(bool mine)
    {
        _setMine = mine && qtyOfMines > 0;
    }

}
