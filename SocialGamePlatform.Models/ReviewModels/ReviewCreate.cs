using System.ComponentModel.DataAnnotations;

namespace SocialGamePlatform.Models.ReviewModels
{
    public class ReviewCreate
    {
        /// <summary>
        /// Id of the game
        /// </summary>
        [Required]
        public int GameId { get; set; }

        /// <summary>
        /// Text for the review
        /// </summary>
        [MaxLength(8000)]
        public string Text { get; set; } = "";

        /// <summary>
        /// Rating for the story
        /// </summary>
        [Required]
        [Range(0, 10)]
        public double StoryRating { get; set; }

        /// <summary>
        /// Rating for the gameplay
        /// </summary>
        [Required]
        [Range(0, 10)]
        public double GameplayRating { get; set; }

        /// <summary>
        /// Rating for the graphics
        /// </summary>
        [Required]
        [Range(0, 10)]
        public double GraphicsRating { get; set; }
    }
}
