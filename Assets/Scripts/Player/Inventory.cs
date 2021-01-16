using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _ballsAmmoQty;
    [SerializeField] private int _minesQty;
    [SerializeField] private GameObject[] _weapons;

    private GameObject _weapon;

    private void Update()
    {
        _weapon = _weapons[0];
        DeActivateOtherWeapons(0, _weapons);

        PlayerInput.OnInputQ += nextWeapon;
    }

    public int BallsAmmoQty
    {
        get { return _ballsAmmoQty; }
        set { _ballsAmmoQty = value; }
    }

    public int MinesQty
    {
        get { return _minesQty; }
        set { _minesQty = value; }
    }

    private void nextWeapon(bool weaponChange)
    {
        if (weaponChange)
        {
            int currentWeaponIndex = Array.IndexOf(_weapons, _weapon);
            int nextWeaponIndex = (currentWeaponIndex + 1) % _weapons.Length;

            _weapon = _weapons[nextWeaponIndex];
            _weapon.SetActive(true);
            DeActivateOtherWeapons(nextWeaponIndex, _weapons);
            Debug.Log(_weapon);
        }
    }
    private void DeActivateOtherWeapons(int currentWeaponIndex, GameObject[] _weapons)
    {
        for (int i = 0; i < _weapons.Length - 1; i++)
            if (i != currentWeaponIndex) _weapons[i].SetActive(false);
    }
}
