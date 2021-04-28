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

        public bool AddAchievement(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accounts
                        .Single(e => e.UserId == _userId);

                entity.Achievements.Add(name);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool AddFollow(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accounts
                        .Single(e => e.UserId == _userId);

                entity.Follows.Add(userName);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool AddGame(string game)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accounts
                        .Single(e => e.UserId == _userId);

                entity.Library.Add(game);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveAchievement(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accounts
                        .Single(e => e.UserId == _userId);

                if (name.ToLower() == "all")
                {
                    entity.Achievements.Clear();
                }
                else
                {
                    entity.Achievements.RemoveAt(entity.Achievements.FindIndex(n => n.Equals("word", StringComparison.OrdinalIgnoreCase)));
                }

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveFollow(string game)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accounts
                        .Single(e => e.UserId == _userId);

                if (game.ToLower() == "all")
                {
                    entity.Follows.Clear();
                }
                else
                {
                    entity.Follows.RemoveAt(entity.Follows.FindIndex(n => n.Equals("word", StringComparison.OrdinalIgnoreCase)));
                }

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveGame(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accounts
                        .Single(e => e.UserId == _userId);

                if (userName.ToLower() == "all")
                {
                    entity.Library.Clear();
                }
                else
                {
                    entity.Library.RemoveAt(entity.Library.FindIndex(n => n.Equals("word", StringComparison.OrdinalIgnoreCase)));
                }

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
