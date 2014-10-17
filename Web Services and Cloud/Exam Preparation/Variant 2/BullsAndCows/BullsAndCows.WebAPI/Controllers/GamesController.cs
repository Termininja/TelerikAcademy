namespace BullsAndCows.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.WebAPI.Models.DataModels;
    using Microsoft.AspNet.Identity;

    public class GamesController : BaseApiController
    {
        const int defaultPageSize = 10;

        public GamesController(IGameData data)
            : base(data)
        {
        }

        //POST: api/games
        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(GameDataModel model)
        {
            var game = new Game
            {
                Name = model.Name,
                RedUserID = model.Red.Id,
                BlueUserID = model.Blue.Id,
                GameState = model.GameState,
                DateCreated = DateTime.Now
            };

            this.data.Games.Add(game);
            this.data.SaveChanges();

            model.ID = game.ID;
            model.DateCreated = game.DateCreated;

            return Ok(model);
        }

        //GET (public): api/games
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Get(0);
        }

        //GET (public): api/games?page=P
        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            var games = GetAllSorted().Skip(page * defaultPageSize).Take(defaultPageSize);

            return Ok(games);
        }

        //GET: api/games/[gameID]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetByID(int id)
        {
            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            var gameModel = new GameDetailsDataModel(game);

            return Ok(gameModel);
        }

        #region Help methods
        private Guess GetGuess(string modelGuess)
        {
            var guess = this.data.Guesses.All().FirstOrDefault(c => c.Username == modelGuess);
            if (guess == null)
            {
                guess = new Guess { Username = modelGuess };
                this.data.Guesses.Add(guess);
            }

            return guess;
        }

        private IEnumerable<GameDataModel> GetAllSorted()
        {
            return this.data.Games.All().OrderByDescending(a => a.DateCreated).Select(GameDataModel.FromGame);
        }
        #endregion
    }
}
