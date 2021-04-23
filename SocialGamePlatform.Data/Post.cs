using Google.Apis.Admin.Directory.directory_v1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]

        public Guid PosterID { get; set; }

        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        [Required]


        public Guid PoserID { get; set; }
        [ForeignKey(nameof(AccountId))]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        [Required]

        public string PosterUserName { get; set; }
        [Required]
        [MinLength(3),MaxLength(240)]
        public string Text { get; set; }
    }
}
