using System.Collections.Generic;
using System.IO;
using SpaceJailRunner.JSON.Interface;
using UnityEngine;

namespace SpaceJailRunner.JSON
{
    internal class MagFactory: ICreateUnits
    {
        private string _fileName = "forParcing.json";
        private string _filePath = "Assets/Scripts/JSON/";
        private string _unitTypeName = "mag";
        public List<Unit> Create()
        {
            var jsonString = File.ReadAllText(Path.Combine(_filePath, _fileName));
            var unit = JsonUtility.FromJson<UnitDataCollection>(jsonString);

            var listOfMagUnits = new List<Unit>();
            for (int i = 0; i < unit.unitData.Count; i++)
            {
                Debug.Log(unit.unitData[i].unit.type);
                if (unit.unitData[i].unit.type == _unitTypeName)
                {
                    var instance = new GameObject(unit.unitData[i].unit.type);
                    var component = instance.AddComponent<Unit>();
                    float health;
                    float.TryParse(unit.unitData[i].unit.health, out health);
                    component.SetHealth(health);
                    component.SetType(unit.unitData[i].unit.type);
                    listOfMagUnits.Add(component);
                }
            }

            return listOfMagUnits;
        }
    }
}