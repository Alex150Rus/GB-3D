using System;
using System.Collections.Generic;
using SpaceJailRunner.JSON.Interface;
using UnityEditorInternal;

namespace SpaceJailRunner.JSON
{
    internal class AbstractUnitFactory: ICreateUnitByType
    {
        private InfantryFactory _infantryFactory;
        private MagFactory _magFactory;
        public AbstractUnitFactory()
        {
            _infantryFactory = new InfantryFactory();
            _magFactory = new MagFactory();
        }
        
        public List<Unit> Create(UnitType type)
        {
            switch (type)
            {
                case UnitType.Infantry:
                    return _infantryFactory.Create();
                case UnitType.Mag:
                    return _magFactory.Create();
                case UnitType.None:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}