using System;

namespace SocialGamePlatform.Models.ReviewModels
{
    public class ReviewListItem
    {
        /// <summary>
        /// ID for the review
        /// </summary>
        public int ReviewId { get; set; }

        /// <summary>
        /// Name of the game being reviewed
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// Username of the reviewer
        /// </summary>
        public string ReviewerUserName { get; set; }

        /// <summary>
        /// Text of the review
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Rating for the story
        /// </summary>
        public double StoryRating { get; set; }

        /// <summary>
        /// Rating for the gameplay
        /// </summary>
        public double GameplayRating { get; set; }

        /// <summary>
        /// Rating for the graphics
        /// </summary>
        public double GraphicsRating { get; set; }

        /// <summary>
        /// Average rating of previous ratings
        /// </summary>
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
