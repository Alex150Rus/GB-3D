using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIHealthController : MonoBehaviour
{
    [SerializeField]
    private Health _health;
    [SerializeField]
    private Image _healthImage;
    [SerializeField]
    private Transform _camera;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_camera);
        _healthImage.fillAmount = (float)_health.CurrentHealth / 100;
    }
}
