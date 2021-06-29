using SpaceJailRunner.Ability.Interface;

namespace SpaceJailRunner.Ability
{
    public class Ability: IAbility
    {
        public string Name { get; }
        public AbilityType Type { get; }
        public int Points { get; }

        public Ability(string name, AbilityType type, int points)
        {
            Name = name;
            Type = type;
            Points = points;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}