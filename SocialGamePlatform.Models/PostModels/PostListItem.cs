using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Models.PostModels
{
    public class PostListItem
    {
        /// <summary>
        /// ID of the post
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// ID of the account posted to
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Username of the poster
        /// </summary>
        public string PosterUserName { get; set; }

        /// <summary>
        /// Post text
        /// </summary>
        public string Text { get; set; }
    }
}
