using SocialGamePlatform.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Models.AccountModels
{
    public class AccountDetail
    {
        public string UserName { get; set; }
        public List<string> Library { get; set; }
        public List<string> Achievements { get; set; }
        public List<Post> Posts { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
