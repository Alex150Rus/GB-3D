using System.Collections.Generic;

namespace SpaceJailRunner.Controller.Enemy.Interface
{
    internal interface IReturnListOfEnemies
    {
        public List<SpaceJailRunner.Enemy.Enemy> GetListOfEnemies();
    }
}