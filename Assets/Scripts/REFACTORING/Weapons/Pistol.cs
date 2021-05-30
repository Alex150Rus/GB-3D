using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pistol : MonoBehaviour

{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private int _shootPower = 200;
    [SerializeField] private float _shootingDistance = 100;
    [SerializeField] private UnityEvent _firing;

    void Start()
    {
        PlayerInput.OnInputFireBtn2 += Fire;
    }

    private void Fire(bool fire)
    {
        if (gameObject.activeSelf && fire && _inventory.PistolAmmoQty > 0)
        {
            RaycastHit hit;

            //Нужен для физики, для обработки наших попаданий
            if(Physics.Raycast(transform.position, transform.forward, out hit, _shootingDistance))
            {
                _firing?.Invoke();
                Instantiate(_prefab, hit.point, Quaternion.identity);
                _inventory.PistolAmmoQty--;
            }
        }
    }

    private void OnDestroy()
    {
        PlayerInput.OnInputFireBtn2 -= Fire;
    }
}
