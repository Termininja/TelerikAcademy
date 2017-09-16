﻿namespace Fitness.Models.UserRegimens
{
    using Fitness.Models.Interfaces;

    /// <summary>
    /// User regimen for person who is beginner and wants to improve his/her body.
    /// </summary>
    public class Rookie : Regimen
    {
        public Rookie(string name, ITrainingProgram trainingProgram, IDiet diet, int duration)
            : base(name, trainingProgram, diet, duration)
        {
        }
    }
}
