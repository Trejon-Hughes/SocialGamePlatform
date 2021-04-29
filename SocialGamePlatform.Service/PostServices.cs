using SocialGamePlatform.Data;
using SocialGamePlatform.Models;
using SocialGamePlatform.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Service
{
    public class PostServices
    {
        private readonly Guid _posterID;
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    PosterID = _posterID,
                    PostName = model.PostName,
                    Text = model.Text,
                    PostId = model.PostId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }
        public IEnumerable<PostListItem> GetPostByName(string post)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.PostName.ToLower() == post.ToLower())
                    .Select(
                        e =>
                            new PostListItem
                            {
                                PostName = e.PostName,
                                PostId = e.PostId,
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
                    .Where(e => e.PostId == id)
                    .Select(
                        e =>
                            new PostListItem
                            {
                                PostName = e.PostName,
                                PostId = e.PostId,
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
                    .Single(e => e.PostId == model.PostId && e.PosterID == _posterID);
                entity.PostName = model.PostName;
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
                    .Single(e => e.PostId == postId && e.PosterID == _posterID);
                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
