using System;

namespace AcademyRPG
{
    public abstract class WorldObject : IWorldObject
    {
        // Properties
        public int HitPoints { get; set; }
        public int Owner { get; private set; }
        public Point Position { get; protected set; }

        public bool IsDestroyed
        {
            get
            {
                return this.HitPoints <= 0;
            }
        }

        // Constructor
        public WorldObject(Point position, int owner)
        {
            this.Position = position;
            this.Owner = owner;
            this.HitPoints = 0;
        }

        // Method
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
