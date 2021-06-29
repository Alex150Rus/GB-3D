using System.Collections;
using System.Collections.Generic;

namespace SpaceJailRunner.Ability.Interface
{
    public interface IHaveAbilities
    {
        IAbility this[int index] { get; }
        string this [AbilityType index] { get; }
        IEnumerable<IAbility> GetAbility();
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility(AbilityType index);
    }
}