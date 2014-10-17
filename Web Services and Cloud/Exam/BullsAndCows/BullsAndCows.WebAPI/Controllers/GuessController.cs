namespace BullsAndCows.WebAPI.Controllers
{
    using System;
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.WebAPI.Models.DataModels;
    using BullsAndCows.Models;
    using Microsoft.AspNet.Identity;

    public class GuessController : BaseApiController
    {
        public GuessController(IGameData data)
            : base(data)
        {
        }

        //POST: api/games/{gameID}/guess
        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(int id, GuessDataModel model)
        {
            var userID = this.User.Identity.GetUserId();
            var guess = new Guess
            {
                Username = model.Username,
                GameID = id,
                Number = model.Number,
                DateMade = DateTime.Now,
                CowsCount = model.CowsCount,
                BullsCount = model.BullsCount
            };

            this.data.Guesses.Add(guess);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
