using Microsoft.AspNet.Identity;
using SocialGamePlatform.Models.GameModels;
using SocialGamePlatform.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace SocialGamePlatform.Web.Controllers
{
    public class GameController : ApiController
    {
        private GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var gameService = new GameService(userId);
            return gameService;
        }

        ///<summary>
        ///Adds a game
        ///</summary>
        [Authorize]
        public IHttpActionResult Post(GameCreate game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.CreateGame(game))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Gets all available games
        /// </summary>
        [ResponseType(typeof(IEnumerable<GameListItem>))]
        public IHttpActionResult Get()
        {
            GameService gameService = CreateGameService();
            var game = gameService.GetAllGames();
            return Ok(game);
        }

        /// <summary>
        /// Searches games by genre or name
        /// </summary>
        /// <param name="selection">Choose to search by genre or name</param>
        /// <param name="search">The string to search by</param>
        [ResponseType(typeof(IEnumerable<GameListItem>))]
        public IHttpActionResult Get(string selection, string search)
        {
            GameService gameService = CreateGameService();
            if (selection.ToLower() == "genre")
            {
                var game = gameService.GetGameByName(search);
                if (game != null)
                {
                    return Ok(game);
                }
                return NotFound();
            }
            else if(selection.ToLower() == "name")
            {
                var game = gameService.GetGameByGenre(search);
                if (game != null)
                {
                    return Ok(game);
                }
                return NotFound();
            }
            else
            {
                return BadRequest("Please enter a valid value for selection");
            }
        }

        /// <summary>
        /// Searches games by price or rating
        /// </summary>
        /// <param name="selection">Choose to search by price or rating</param>
        /// <param name="value">The search value</param>
        [ResponseType(typeof(IEnumerable<GameListItem>))]
        public IHttpActionResult Get(string selection, double value)
        {
            GameService gameService = CreateGameService();
            if (selection.ToLower() == "rating")
            {
                var game = gameService.GetGameByRating(value);
                if (game != null)
                {
                    return Ok(game);
                }
                return NotFound();
            }
            else if (selection.ToLower() == "price")
            {
                var game = gameService.GetGameByPrice(Convert.ToDecimal(value));
                if (game != null)
                {
                    return Ok(game);
                }
                return NotFound();
            }
            else
            {
                return BadRequest("Please enter a valid value for selection");
            }

        }

        /// <summary>
        /// Allows an account to update a game they created
        /// </summary>
        [Authorize]
        public IHttpActionResult Put(GameEdit game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateGameService();

            if (!service.UpdateGame(game))
            {
                return InternalServerError();
            }

            return Ok();
        }

        /// <summary>
        /// Allows an account to delete a game they created
        /// </summary>
        /// <param name="id">Id of the game to be deleted</param>
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGameService();

            if (!service.DeleteGame(id))
            {
                return InternalServerError();
            }

            return Ok();
        }

    }
}
