using System;
using System.Collections.Generic;
using System.IO;
using SpaceJailRunner.JSON.Interface;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SpaceJailRunner.JSON
{
    internal class InfantryFactory: ICreateUnits
    {
        private string _fileName = "forParcing.json";
        private string _filePath = "Assets/Scripts/JSON/";
        private string _unitTypeName = "infantry";
        public List<Unit> Create()
        {
            var jsonString = File.ReadAllText(Path.Combine(_filePath, _fileName));
            var unit = JsonUtility.FromJson<UnitDataCollection>(jsonString);

            var listOfInfantryUnits = new List<Unit>();
            for (int i = 0; i < unit.unitData.Count; i++)
            {
                if (unit.unitData[i].unit.type == _unitTypeName)
                {
                    var instance = new GameObject(unit.unitData[i].unit.type);
                    var component = instance.AddComponent<Unit>();
                    float health;
                    float.TryParse(unit.unitData[i].unit.health, out health);
                    component.SetHealth(health);
                    component.SetType(unit.unitData[i].unit.type);
                    listOfInfantryUnits.Add(component);
                }
            }

            return listOfInfantryUnits;
        }
    }
}