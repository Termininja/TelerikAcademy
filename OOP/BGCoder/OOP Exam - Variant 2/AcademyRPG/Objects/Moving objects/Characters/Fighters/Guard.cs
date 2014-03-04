using System.Collections.Generic;

namespace AcademyRPG
{
    public class Guard : Character, IFighter
    {
        // Constructor
        public Guard(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 100;
        }

        // Properties
        public int AttackPoints
        {
            get { return 50; }
        }

        public int DefensePoints
        {
            get { return 20; }
        }

        // Method
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
