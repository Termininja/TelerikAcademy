using System.Collections.Generic;

namespace AcademyRPG
{
    public interface IFighter : IControllable
    {
        // Properties
        int AttackPoints { get; }
        int DefensePoints { get; }

        // Method
        int GetTargetIndex(List<WorldObject> availableTargets);
    }
}
