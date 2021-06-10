using System.Collections.Generic;

namespace SpaceJailRunner.Controller.Enemy.Interface
{
    internal interface IReturnListOfPatrollingEnemies
    {
        public List<SpaceJailRunner.Enemy.Enemy> GetPatrollingEnemies();
    }
}