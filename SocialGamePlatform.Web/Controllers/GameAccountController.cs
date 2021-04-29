using Microsoft.AspNet.Identity;
using SocialGamePlatform.Models.AccountModels;
using SocialGamePlatform.Service;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace SocialGamePlatform.Web.Controllers
{

    public class GameAccountController : ApiController
    {
        private AccountService CreateAccountService()
        {
            if(User.Identity.GetUserId() == null)
            {
                var accountService = new AccountService(default(Guid));
                return accountService;
            }
            else
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var accountService = new AccountService(userId);
                return accountService;
            }
        }

        /// <summary>
        /// Get an account by username
        /// </summary>
        /// <param name="name">Account's username</param>
        [ResponseType(typeof(AccountDetail))]
        public IHttpActionResult Get(string name)
        {
            AccountService accountService = CreateAccountService();
            var account = accountService.GetAccountByUsername(name);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        /// <summary>
        /// Adds a new account associated with the creator
        /// </summary>
        [Authorize]
        public IHttpActionResult Post()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateAccountService();

            if (!service.CreateAccount())
            {
                return InternalServerError();
            }

            return Ok();
        }

        ///// <summary>
        ///// Adds an achievement name, game, or user follow to the owner's account
        ///// </summary>
        ///// <param name="action">Name of the action to take. Achievement, Game, or Follow</param>
        ///// <param name="name">Name of the item to add</param>
        //[Authorize]
        //public IHttpActionResult Put(string action, string name)
        //{
        //    var service = CreateAccountService();
        //    if (action.ToLower() == "achievement")
        //    {
        //        if (!service.AddAchievement(name))
        //        {
        //            return InternalServerError();
        //        }

        //        return Ok();
        //    }
        //    else if (action.ToLower() == "game")
        //    {
        //        if (!service.AddGame(name))
        //        {
        //            return InternalServerError();
        //        }

        //        return Ok();
        //    }
        //    else if (action.ToLower() == "follow")
        //    {
        //        if (!service.AddFollow(name))
        //        {
        //            return InternalServerError();
        //        }

        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest("Please enter a valid value for action");
        //    }
        //}

        ///// <summary>
        ///// Removes an achievement, game, or follow from the owner's account by name
        ///// </summary>
        ///// <param name="name">Name of the object to remove, enter "all" to remove all</param>
        ///// <param name="action">Name of the action to take. Achievement, Game, or Follow</param>
        //[Authorize]
        //public IHttpActionResult Delete(string action, string name)
        //{
        //    var service = CreateAccountService();
        //    if (action.ToLower() == "achievement")
        //    {
        //        if (!service.RemoveAchievement(name))
        //        {
        //            return InternalServerError();
        //        }

        //        return Ok();
        //    }
        //    else if (action.ToLower() == "game")
        //    {
        //        if (!service.RemoveGame(name))
        //        {
        //            return InternalServerError();
        //        }

        //        return Ok();
        //    }
        //    else if (action.ToLower() == "follow")
        //    {
        //        if (!service.RemoveFollow(name))
        //        {
        //            return InternalServerError();
        //        }

        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest("Please enter a valid value for action");
        //    }
        //}
    }
}
