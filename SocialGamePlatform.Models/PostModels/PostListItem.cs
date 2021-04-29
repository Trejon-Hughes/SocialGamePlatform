using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Models.PostModels
{
    public class PostListItem
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string PosterUserName { get; set; }
        public string Text { get; set; }
    }
}
