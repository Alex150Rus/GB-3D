using System;

namespace SpaceJailRunner.JSON
{
    [Serializable]
    internal struct UnitData
    {
        public Unit unit;
        
        [Serializable]
        public struct Unit
        {
            public string type;
            public string health;

            public Unit(string type, string health)
            {
                this.type = type;
                this.health = health;
            }
        }

        public UnitData(string type, string health)
        {
            this.unit = new Unit(type, health);
        }
    }
}