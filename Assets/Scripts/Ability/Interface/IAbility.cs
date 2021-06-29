namespace SpaceJailRunner.Ability.Interface
{
    public interface IAbility
    {
        string Name { get; }
        AbilityType Type { get; }
        int Points { get; }
    }
}