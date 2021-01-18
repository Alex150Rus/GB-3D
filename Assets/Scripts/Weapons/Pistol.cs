using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour

{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private int _shootPower = 200;
    [SerializeField] private float _shootingDistance = 100;

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
                Instantiate(_prefab, hit.point, Quaternion.identity);
                Debug.Log("fire");
            }
            

        }
    }
}
