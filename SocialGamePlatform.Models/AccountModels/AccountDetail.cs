using SocialGamePlatform.Data;
using System.Collections.Generic;

namespace SocialGamePlatform.Models.AccountModels
{
    public class AccountDetail
    {
        /// <summary>
        /// Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User's Library
        /// </summary>
        public List<string> Library { get; set; }

        /// <summary>
        /// User's Achievements
        /// </summary>
        public List<string> Achievements { get; set; }

        /// <summary>
        /// User's Posts
        /// </summary>
        public List<Post> Posts { get; set; }

        /// <summary>
        /// User's Reviews
        /// </summary>
        public List<Review> Reviews { get; set; }
    }
}
