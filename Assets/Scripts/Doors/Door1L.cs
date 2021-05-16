using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1L : MonoBehaviour

{
    [SerializeField] private Transform _openableDoor;
    [SerializeField] private bool _keyNeeded = false;
    [SerializeField] private bool _opened = false;
    [SerializeField] private string[] _tagsToReact = { "Player", "Enemy", };

    private GameObject _collisionGameObject;
    private enum State
    {
        Closed,
        Opened,
    }
   private State _state;

    private void Start()
    {
        _state = _opened ? State.Opened : State.Closed;
    }

    private void OnTriggerEnter(Collider other)
    {
        _collisionGameObject = other.gameObject;
        foreach (string tag in _tagsToReact)
        {
            if (_collisionGameObject.CompareTag(tag))
            {
                OpenDoor();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (string tag in _tagsToReact)
        {
            if (_collisionGameObject.CompareTag(tag))
            {
                CloseDoor();
            }
        }
    }

    private void CloseDoor()
    {
        if (_state == State.Opened)
        {
            _openableDoor.gameObject.SetActive(true);
            _state = State.Closed;
        }
    }

    private void OpenDoor()
    {
        if (_state == State.Closed && ValidateKey())
        {
            _openableDoor.gameObject.SetActive(false);
            _state = State.Opened;
        }
    }

   private bool ValidateKey()
    {
        if (_keyNeeded)
        {
            return false;
        }

        return true;
    }
}
