using System;
using SpaceJailRunner.Controller;
using SpaceJailRunner.Controller.Interface;
using UnityEngine;

namespace SpaceJailRunner
{
    internal class Application : MonoBehaviour
    {
        [ SerializeField ]
        private Data.Data _data;
        private Controllers _controllers;
        private void Start()
        {
            _controllers = new Controllers();
            new Game(_controllers, _data);
            _controllers.Init();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            _controllers.FixedExecute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.CleanUp();
        }
    }
}