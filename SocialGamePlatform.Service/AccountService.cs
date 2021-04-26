using Microsoft.AspNet.Identity;
using SocialGamePlatform.Data;
using SocialGamePlatform.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialGamePlatform.Service
{
    public class AccountService
    {
        private readonly Guid _userId;

        public AccountService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAccount()
        {
            var entity =
                new Account()
                {
                    UserId = _userId,
                    UserName = Thread.CurrentPrincipal.Identity.GetUserName()
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Accounts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public object GetAccountById(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accounts
                        .Single(e => e.UserName == name);
                return 
                    new AccountDetail
                    {
                        UserName = entity.UserName,
                        Achievements = entity.Achievements,
                        Library = entity.Library,
                        Posts = entity.Posts,
                        Reviews = entity.Reviews
                    };
            }
        }
    }
}
