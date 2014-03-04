using System.Collections.Generic;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        // Field
        private int attackPoints;

        // Constructor
        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.attackPoints = 0;
        }

        // Properties
        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        // Methods
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int highestHitPoints = 0;
            int target = 0;
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (availableTargets[i].HitPoints > highestHitPoints)
                    {
                        target = i;
                        highestHitPoints = availableTargets[i].HitPoints;
                    }
                }
            }
            return target;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints += 2 * resource.Quantity;
                return true;
            }
            if (resource.Type == ResourceType.Lumber)
            {
                this.attackPoints += resource.Quantity;
                return true;
            }

            return false;
        }
    }
}
