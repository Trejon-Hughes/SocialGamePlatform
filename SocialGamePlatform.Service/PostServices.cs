using SocialGamePlatform.Data;
using SocialGamePlatform.Models;
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
                    Text = model.Text,
                    PostId = model.PostId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
