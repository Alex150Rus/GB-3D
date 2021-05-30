namespace SpaceJailRunner.Enemy.Interface
{
    internal interface ICreateEnemyByType
    {
        public Enemy Create(EnemyType enemyType);
    }
}