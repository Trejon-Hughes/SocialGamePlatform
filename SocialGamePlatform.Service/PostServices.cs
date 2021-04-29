using Microsoft.AspNet.Identity;
using SocialGamePlatform.Data;
using SocialGamePlatform.Models;
using SocialGamePlatform.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialGamePlatform.Service
{
    public class PostServices
    {
        private readonly Guid _posterID;

        public PostServices(Guid userId)
        {
            _posterID = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    PosterID = _posterID,
                    AccountId = model.AccountId,
                    Text = model.Text,
                    PosterUserName = Thread.CurrentPrincipal.Identity.GetUserName()
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }
        public IEnumerable<PostListItem> GetPostByUsername(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .ToList()
                    .Where(e => e.PosterUserName.ToLower() == userName.ToLower())
                    .Select(
                        e =>
                            new PostListItem
                            {
                                PostId = e.PostId,
                                AccountId = e.AccountId,
                                PosterUserName = e.PosterUserName,
                                Text = e.Text
                            }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<PostListItem> GetPostByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .ToList()
                    .Where(e => e.PostId == id)
                    .Select(
                        e =>
                            new PostListItem
                            {
                                PostId = e.PostId,
                                AccountId = e.AccountId,
                                PosterUserName = e.PosterUserName,
                                Text = e.Text
                            }
                        );
                return query.ToArray();
            }
        }
        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .SingleOrDefault(e => e.PostId == model.PostId && e.PosterID == _posterID);

                if(entity == null)
                {
                    return false;
                }
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .SingleOrDefault(e => e.PostId == postId && e.PosterID == _posterID);

                if (entity == null)
                {
                    return false;
                }
                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
