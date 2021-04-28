using Microsoft.AspNet.Identity;
using SocialGamePlatform.Models.AchievementModels;
using SocialGamePlatform.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SocialGamePlatform.Web.Controllers
{
    public class AchievementController : ApiController
    {
        private AchievementService CreateAchievementService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var achievementService = new AchievementService(userId);
            return achievementService;
        }

        /// <summary>
        /// Adds a review to a game
        /// </summary>
        [Authorize]
        public IHttpActionResult Post(AchievementCreate achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateAchievementService();

            if (!service.CreateAchievement(achievement))
            {
                return InternalServerError();
            }

            return Ok();
        }

        /// <summary>
        /// Searches achievements by achievement name or game
        /// </summary>
        /// <param name="selection">Choose to search by game or achievement name</param>
        /// <param name="search">The string to search by</param>
        /// <returns></returns>
        [ResponseType(typeof(IEnumerable<AchievementListItem>))]
        public IHttpActionResult Get(string selection, string search)
        {
            AchievementService achievementService = CreateAchievementService();
            if (selection.ToLower() == "name")
            {
                var achievement = achievementService.GetAchievementByName(search);
                if (achievement != null)
                {
                    return Ok(achievement);
                }
                return NotFound();
            }
            else if (selection.ToLower() == "game")
            {
                var achievement = achievementService.GetAchievementByGame(search);
                if (achievement != null)
                {
                    return Ok(achievement);
                }
                return NotFound();
            }
            else
            {
                return BadRequest("Please enter a valid value for selection");
            }
        }

        /// <summary>
        /// Searches for achievement by ID
        /// </summary>
        /// <param name="id">ID of the achievement</param>
        [ResponseType(typeof(IEnumerable<AchievementListItem>))]
        public IHttpActionResult Get(int id)
        {
            AchievementService achievementService = CreateAchievementService();

            var achievement = achievementService.GetAchievementById(id);
            if (achievement != null)
            {
                return Ok(achievement);
            }
            return NotFound();
        }

        /// <summary>
        /// Allows an account to update an achievement they created
        /// </summary>
        [Authorize]
        public IHttpActionResult Put(AchievementEdit achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateAchievementService();

            if (!service.UpdateAchievement(achievement))
            {
                return InternalServerError();
            }

            return Ok();
        }

        /// <summary>
        /// Allows an account to delete an achievement they created
        /// </summary>
        /// <param name="id">Id of the achievement to be deleted</param>
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAchievementService();

            if (!service.DeleteAchievement(id))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
