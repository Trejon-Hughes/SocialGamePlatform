using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialGamePlatform.Data
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [JsonIgnore]
        public Guid UserId { get; set; }
        //public List<string> Follows { get; set; } = new List<string>();
        //public List<string> Library { get; set; } = new List<string>();
        //public List<string> Achievements { get; set; } = new List<string>();
        public virtual List<Post> Posts { get; set; } = new List<Post>();
        public virtual List<Review> Reviews { get; set; } = new List<Review>();

    }
}
