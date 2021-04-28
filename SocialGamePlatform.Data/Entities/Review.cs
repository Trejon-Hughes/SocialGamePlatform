using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialGamePlatform.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        [JsonIgnore]
        public Guid ReviewerId { get; set; }

        [ForeignKey(nameof(Account))]
        [JsonIgnore]
        public int AccountId { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }

        [ForeignKey(nameof(Game))]
        [JsonIgnore]
        public int GameId { get; set; }
        [JsonIgnore]
        public virtual Game Game { get; set; }

        public string GameName { get; set; }

        [Required]
        public string ReviewerUserName { get; set; }

        [MaxLength(8000)]
        public string Text { get; set; } = "";

        [Required]
        [Range(0, 10)]
        public double StoryRating { get; set; }

        [Required]
        [Range(0, 10)]
        public double GameplayRating { get; set; }

        [Required]
        [Range(0, 10)]
        public double GraphicsRating { get; set; }

        public double AverageRating
        {
            get
            {
                var totalScore = StoryRating + GameplayRating + GraphicsRating;
                return Math.Round((totalScore / 3), 2);
            }
        }
    }
}
