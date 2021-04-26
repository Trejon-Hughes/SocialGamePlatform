using Microsoft.AspNet.Identity;
using SocialGamePlatform.Service;
using SocialGamePlatform.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialGamePlatform.Web.Controllers
{
    [Authorize]
    public class GameAccountController : ApiController
    {
        private AccountService CreateAccountService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var accountService = new AccountService(userId);
            return accountService;
        }

        public IHttpActionResult Get(string name)
        {
            AccountService accountService = CreateAccountService();
            var account = accountService.GetAccountById(name);
            return Ok(account);
        }

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
    }
}
