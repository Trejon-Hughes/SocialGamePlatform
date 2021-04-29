using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialGamePlatform.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string OwnerUserName { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Review> Reviews { get; set; } = new List<Review>();

        public double Rating { get; set; } = 0;

        public double GetRating()
        {
            double totalAverageRating = 0;

            foreach (var rating in Reviews)
            {
                totalAverageRating += rating.AverageRating;
            }
            double averageRating = Reviews.Count > 0 ? Math.Round(totalAverageRating / Reviews.Count, 2) : 0;
            Rating = averageRating;
            return averageRating;
        }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual List<Achievement> Achievements { get; set; } = new List<Achievement>();
        //[Required]
        //public virtual List<string> GenreTags { get; set; } = new List<string>();
    }
}
