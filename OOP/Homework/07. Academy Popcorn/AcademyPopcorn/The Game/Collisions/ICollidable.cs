using System.Collections.Generic;

namespace AcademyPopcorn
{
    // The object can be collided
    public interface ICollidable
    {
        // Is it possible the object to be collided with something
        bool CanCollideWith(string objectType);

        // List of object coordinates
        List<MatrixCoords> GetCollisionProfile();

        // What to be done after collision
        void RespondToCollision(CollisionData collisionData);

        string GetCollisionGroupString();
    }
}
