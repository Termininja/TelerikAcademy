/*
 * Task 1: Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed).
 *         You are not allowed to edit any existing class.
 * 
 * Task 2: Test the ChaoticParticle through the ParticleSystemMain class.
 * 
 * Task 3: Create a ChickenParticle class. The ChickenParticle class moves like a ChaoticParticle,
 *         but randomly stops at different positions for several simulation ticks and, for each of those stops,
 *         creates (lays) a new ChickenParticle. You are not allowed to edit any existing class.
 * 
 * Task 4: Test the ChickenParticle class through the ParcticleSystemMain class.
 * 
 * Task 5: Implement a ParticleRepeller class. A ParticleRepeller is a Particle, which pushes other particles
 *         away from it (i.e. accelerates them in a direction, opposite of the direction in which the repeller is).
 *         The repeller has an effect only on particles within a certain radius (see Euclidean distance).
 * 
 * Task 6: Test the ParticleRepeller class through the ParticleSystemMain class.
 */

using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    class Program
    {
        const int GameRows = 20;
        const int GameCols = 70;
        const int Delay = 200;

        static readonly Random RandomGenerator = new Random();

        static void Main()
        {
            // Set console window width and height
            Console.BufferWidth = Console.WindowWidth = GameCols + 1;
            Console.WindowHeight = Console.WindowHeight = GameRows + 2;

            ConsoleRenderer renderer = new ConsoleRenderer(GameRows, GameCols);
            ParticleUpdater updater = new AdvancedParticleUpdater();

            // Create a list of particles
            List<Particle> particles = new List<Particle>()
            {
                // normal particle
                new Particle(new MatrixCoords(4, 0), new MatrixCoords(0, 1)),

                // emitter particle
                new VariousParticleEmitter(new MatrixCoords(7, 5), new MatrixCoords(0, 0), RandomGenerator), 

                // repeller particles
                new ParticleRepeller(new MatrixCoords(18, 25), new MatrixCoords(0, 0), 1),
                new ParticleRepeller(new MatrixCoords(3, 65), new MatrixCoords(0, 0), 1),
                new ParticleRepeller(new MatrixCoords(12, 57), new MatrixCoords(0, 0), 1),

                // attractor particle
                new ParticleAttractor(new MatrixCoords(12, 50), new MatrixCoords(0, 0), 1),

                // chaotic particle
                new ChaoticParticle(new MatrixCoords(12, 40), new MatrixCoords(0, 0), RandomGenerator),

                // chicken particle
                new ChickenParticle(new MatrixCoords(12, 40), new MatrixCoords(0, 0), RandomGenerator)
            };

            // Create and run some engine
            Engine engine = new Engine(renderer, updater, particles, Delay);
            engine.Run();
        }
    }
}
