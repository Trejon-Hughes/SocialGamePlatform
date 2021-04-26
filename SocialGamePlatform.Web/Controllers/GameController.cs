using Microsoft.AspNet.Identity;
using SocialGamePlatform.Data;
using SocialGamePlatform.Models.GameModels;
using SocialGamePlatform.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialGamePlatform.Web.Controllers
{
    [Authorize]
    public class GameController : ApiController
    {
        private GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var gameService = new GameService(userId);
            return gameService;
        }

        public IHttpActionResult Post(GameCreate game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.CreateGame(game))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            GameService gameService = CreateGameService();
            var game = gameService.GetAllGames();
            return Ok(game);
        }

        public IHttpActionResult Get(string selection, string search)
        {
            GameService gameService = CreateGameService();
            if (selection.ToLower() == "genre")
            {
                var game = gameService.GetGameByName(search);
                return Ok(game);
            }
            else if(selection.ToLower() == "name")
            {
                var game = gameService.GetGameByGenre(search);
                return Ok(game);
            }
            else
            {
                return BadRequest("Please Enter Genre or Name as selection");
            }
        }

        public IHttpActionResult Get(string selection, double value)
        {
            GameService gameService = CreateGameService();
            if (selection.ToLower() == "rating")
            {
                var game = gameService.GetGameByRating(value);
                return Ok(game);
            }
            else if (selection.ToLower() == "price")
            {
                var game = gameService.GetGameByPrice(Convert.ToDecimal(value));
                return Ok(game);
            }
            else
            {
                return BadRequest("Please Enter Rating or Price as selection");
            }

        }

    }
}
