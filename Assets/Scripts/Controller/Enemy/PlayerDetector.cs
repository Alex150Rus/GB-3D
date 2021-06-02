using System;
using System.Collections.Generic;
using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Enemy.Interface;
using SpaceJailRunner.Player.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.Enemy
{
    internal class PlayerDetector : IExecute
    {
        private IDetectEnemy _detector;
        private Transform _target;
        private List<SpaceJailRunner.Enemy.Enemy> _sources;
        private IHaveHealth _player; 
        
        public PlayerDetector(IDetectEnemy detector, SpaceJailRunner.Player.Player target,
            List<SpaceJailRunner.Enemy.Enemy> sources)
        {
            _detector = detector;
            _target = target.transform;
            _sources = sources;
            _player = target;
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _sources.Count; i++)
            {
                if (_detector.Detect(_sources[i].transform, _target))
                {   
                    _sources[i].EnemyIsInSight = true;
                    _sources[i].SetTarget(_player);
                }
                else
                    _sources[i].EnemyIsInSight = false;
            }
        }
    }
}