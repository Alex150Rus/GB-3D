using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private Vector3 _fieldSize;
    [SerializeField] private float _delayInSeconds = 2;
    [SerializeField] private int _qtyOfBalls = 10;
   
    void Start()
    {
        StartCoroutine(AutoSpawn());
    }
    
    private IEnumerator AutoSpawn()
    {
        while(_qtyOfBalls > 0)
        {
            //операция не самая лёгкая. Нужно использовать пулл объектов
            Instantiate(_ballPrefab, _parent.position, Quaternion.identity, _parent);
            _qtyOfBalls--;
            yield return new WaitForSeconds(_delayInSeconds);
        }

    }

}
