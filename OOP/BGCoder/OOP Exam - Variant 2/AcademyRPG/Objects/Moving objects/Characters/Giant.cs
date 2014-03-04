using System.Collections.Generic;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        // Fields
        private bool isTaken;
        private int attackPoints;

        // Constructor
        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
            this.isTaken = false;
            this.attackPoints = 150;
        }

        // Properties
        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        // Methods
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0) return i;
            }
            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!isTaken)
                {
                    this.attackPoints += 100;
                    isTaken = true;
                }
                return true;
            }
            return false;
        }
    }
}
