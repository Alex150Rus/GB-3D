using System.Collections.Generic;

namespace SpaceJailRunner.JSON.Interface
{
    internal interface ICreateUnitByType
    {
        public List<Unit> Create(UnitType type);
    }
}