namespace BullsAndCows.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using System.Net.Http;

    using BullsAndCows.Data;
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;
    using BullsAndCows.WebAPI.Controllers;
    using BullsAndCows.WebAPI.Models.DataModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class GameControllerClass
    {
        [TestMethod]
        public void GetAll_WhenGamesInDb_ShouldReturnGames()
        {
            var repository = Mock.Create<IRepository<Game>>();
            Game[] games = this.GenerateValidTestGames(1);
            Mock.Arrange(() => repository.All())
                .Returns(() => games.AsQueryable());

            var data = Mock.Create<IGameData>();
            Mock.Arrange(() => data.Games)
                .Returns(() => repository);

            var controller = new GamesController(data);
            this.SetupController(controller);

            //Test "Get"
            var actionResult = controller.Get();

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<GameDataModel>>().Result.Select(a => a.ID).ToList();

            var expected = games.AsQueryable().Select(a => a.ID).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetAll_When16GamesInDb_ShouldReturn10Games()
        {
            var repository = Mock.Create<IRepository<Game>>();
            Game[] games = this.GenerateValidTestGames(16);
            Mock.Arrange(() => repository.All())
                .Returns(() => games.AsQueryable());

            var data = Mock.Create<IGameData>();
            Mock.Arrange(() => data.Games)
                .Returns(() => repository);

            var controller = new GamesController(data);
            this.SetupController(controller);

            //Test "Get"
            var actionResult = controller.Get();

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<GameDataModel>>().Result.Select(a => a.ID).ToList();

            var expected = games.AsQueryable().OrderByDescending(a => a.DateCreated).Take(10).Select(a => a.ID).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        private Game[] GenerateValidTestGames(int count)
        {
            Game[] games = new Game[count];
            var guess = new Guess
            {
                ID = 1,
                Username = "Test Guess"
            };

            for (int i = 0; i < count; i++)
            {
                games[i] = new Game
                {
                    ID = i,
                    Name = "Title #" + i,
                    DateCreated = DateTime.Now,
                    BlueUser = new User()
                };
            }

            return games;
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "games" }
                    });
        }
    }
}
