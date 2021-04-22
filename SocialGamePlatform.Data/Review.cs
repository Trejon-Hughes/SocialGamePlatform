using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public Guid ReviewerId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        [ForeignKey(nameof(GameId))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        [Required]
        public string ReviewerUserName { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Text { get; set; }

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
                return totalScore / 3;
            }
        }
    }
}
