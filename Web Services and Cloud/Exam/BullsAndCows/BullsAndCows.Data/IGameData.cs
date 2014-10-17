namespace BullsAndCows.Data
{
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public interface IGameData
    {
        IRepository<Game> Games { get; }

        IRepository<Guess> Guesses { get; }

        int SaveChanges();
    }
}
