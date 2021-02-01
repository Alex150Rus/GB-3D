using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _ballsAmmoQty;
    [SerializeField] private int _minesQty;
    [SerializeField] private int _PistolAmmoQty;
    [SerializeField] private GameObject[] _weapons;

    [Header("Tags")]
    [SerializeField] private string _ballAmmoTag = "BallAmmo";
    [SerializeField] private string _firstAidTag = "FirstAid";
    [SerializeField] private string _keyCardTag = "KeyCard";

    private GameObject _weapon;
    private string _currentWeaponName;

    private int _firstAidQty = 0;
    private int _keyCardsQty = 0;

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

    public int PistolAmmoQty
    {
        get { return _PistolAmmoQty; }
        set { _PistolAmmoQty = value; }
    }

    public string CurrentWeaponName
    {
        get { return _currentWeaponName; }     
    }

    public string BallAmmoTag { get => _ballAmmoTag;}
    public string FirstAidTag { get => _firstAidTag;}
    public string KeyCardTag { get => _keyCardTag;}
    public int FirstAidQty { get => _firstAidQty; set => _firstAidQty = value; }
    public int KeyCardsQty { get => _keyCardsQty; set => _keyCardsQty = value; }

    private void Start()
    {
        _weapon = _weapons[0];
        _currentWeaponName = _weapon.name;
        DeActivateOtherWeapons(0, _weapons);

        PlayerInput.OnInputQ += nextWeapon;
    }


    private void nextWeapon(bool weaponChange)
    {
        if (weaponChange)
        {
            int currentWeaponIndex = Array.IndexOf(_weapons, _weapon);
            int nextWeaponIndex = (currentWeaponIndex + 1) % _weapons.Length;

            _weapon = _weapons[nextWeaponIndex];
            _currentWeaponName = _weapon.name;
            _weapon.SetActive(true);
            DeActivateOtherWeapons(nextWeaponIndex, _weapons);
        }
    }
    private void DeActivateOtherWeapons(int currentWeaponIndex, GameObject[] _weapons)
    {
        for (int i = 0; i < _weapons.Length; i++) if (i != currentWeaponIndex) _weapons[i].SetActive(false);            
    }

    private void OnDestroy()
    {
        PlayerInput.OnInputQ -= nextWeapon;
    }
}
