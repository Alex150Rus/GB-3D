using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using SpaceJailRunner.NameManager;

namespace SpaceJailRunner.Ammos
{
    internal sealed class AmmoPool
    {
        private readonly Dictionary<string, HashSet<Ammo>> _ammoPool;
        private readonly int _capacityPool;
        private Transform _rootPool;
        private AmmoAbstractFactory _ammoAbstractFactory;
        
        
        public AmmoPool(int capacityPool, AmmoAbstractFactory ammoAbstractFactory)
        {
            _ammoPool = new Dictionary<string, HashSet<Ammo>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.NameManager.POOL_AMMO).transform;
            }

            _ammoAbstractFactory = ammoAbstractFactory;
        }
        
        public Ammo GetOneAmmo(AmmoType ammoType)
        {
            Ammo result;
            result = GetAmmo(GetListAmmos(ammoType), ammoType);  
            return result;
        }

        private HashSet<Ammo> GetListAmmos(AmmoType ammoType)
        {
            return _ammoPool.ContainsKey(ammoType.ToString()) ? 
                _ammoPool[ammoType.ToString()] : _ammoPool[ammoType.ToString()] = new HashSet<Ammo>();
        }

        private Ammo GetAmmo(HashSet<Ammo> ammos,AmmoType ammoType)
        {
            var ammo = ammos.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (ammo == null )
            {
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = _ammoAbstractFactory.CreateAmmo(ammoType);
                    ReturnToPool(instantiate.transform);
                    ammos.Add(instantiate);
                }

                GetAmmo(ammos, ammoType);
            }
            ammo = ammos.FirstOrDefault(a => !a.gameObject.activeSelf);
            return ammo;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}