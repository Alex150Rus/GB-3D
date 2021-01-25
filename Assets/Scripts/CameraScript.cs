using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _x = 4;
    [SerializeField] private float _y = 8;
    [SerializeField] private float _z = 4;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInput.OnInputMMB = RotateCamera;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.position.x - _x, transform.position.y - _y, _player.position.z - _z);
    }

    private void RotateCamera(bool input, Vector3 lookto)
    {

        if (input)
        {

        }						
    }
}
