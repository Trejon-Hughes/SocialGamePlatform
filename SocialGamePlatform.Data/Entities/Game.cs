using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double Rating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (var rating in Reviews)
                {
                    totalAverageRating += rating.AverageRating;
                }
                return Reviews.Count > 0 ? Math.Round(totalAverageRating / Reviews.Count, 2) : 0;
            }
        }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Target Price; Max 18 digits")]
        public decimal Price { get; set; }

        public string Description { get; set; }
        //public List<Achievement> Achievements { get; set; } = new List<Achievement>();
        [Required]
        public List<string> GenreTags { get; set; }
    }
}
