using System.Collections.Generic;

namespace SpaceJailRunner.Controller.Enemy.Interface
{
    public interface IReturnListOfPatrollingEnemies
    {
        public List<SpaceJailRunner.Enemy.Enemy> GetPatrollingEnemies();
    }
}