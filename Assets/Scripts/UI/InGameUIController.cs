using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class InGameUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _weaponName;
    [SerializeField] private TextMeshProUGUI _ammoQty;
    [SerializeField] private TextMeshProUGUI _keyCardQty;
    [SerializeField] private TextMeshProUGUI _firstAidQty;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Health _health;
    [SerializeField] private Inventory _inventory;

    // Update is called once per frame
    void Update()
    {
        _healthBar.fillAmount = (float)_health.CurrentHealth/100;
        _keyCardQty.text = _inventory.KeyCardsQty.ToString();
        _firstAidQty.text = _inventory.FirstAidQty.ToString();
        string weaponName = _weaponName.text = _inventory.CurrentWeaponName;
        ShowAmmoQty(weaponName);
    }

    private void ShowAmmoQty(string weaponName)
    {
        switch (weaponName)
        {
            case "Thrower":
                _ammoQty.text = _inventory.BallsAmmoQty.ToString();
                break;
            case "Pistol":
                _ammoQty.text = _inventory.PistolAmmoQty.ToString();
                break;
            case "Mine":
                _ammoQty.text = _inventory.MinesQty.ToString();
                break;
            default:
                break;
        }
    }
}
