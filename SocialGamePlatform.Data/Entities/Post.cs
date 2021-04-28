using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialGamePlatform.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [JsonIgnore]
        public Guid PosterID { get; set; }

        [ForeignKey(nameof(Account))]
        [JsonIgnore]
        public int AccountId { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }

        [Required]
        public string PosterUserName { get; set; }

        [Required]
        [MinLength(3),MaxLength(240)]
        public string Text { get; set; }
    }
}
