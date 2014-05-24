using System.Collections.Generic;

namespace ParticleSystem
{
    public interface IParticle
    {
        MatrixCoords Position { get; }
        bool Exists { get; }

        IEnumerable<IParticle> Update();
    }
}
