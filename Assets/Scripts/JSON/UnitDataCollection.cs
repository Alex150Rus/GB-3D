using System;
using System.Collections.Generic;

namespace SpaceJailRunner.JSON
{
    [Serializable]
    internal class UnitDataCollection
    {
        public List<UnitData> unitData;

        public UnitDataCollection()
        {
            unitData = new List<UnitData>();
        }
    }
}