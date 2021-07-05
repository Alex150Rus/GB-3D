using SpaceJailRunner.Health;

namespace SpaceJailRunner.Listeners.Interface
{
    internal interface IHealthListener
    {
        public void Add(IHealth health);
        public void Remove(IHealth health);
    }
}