using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialGamePlatform.Models.GameModels
{
    public class GameCreate
    {
        /// <summary>
        /// Name of the game
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Price of the game, Max of 2 decimal places, Between 0 and 9999.99
        /// </summary>
        [Required]
        [RegularExpression(@"^[+-]?[0-9]{1,3}(?:,?[0-9]{3})*(?:\.[0-9]{2})?$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
        [Range(0, 9999.99, ErrorMessage = "Invalid Target Price; Max 6 digits")]
        public decimal Price { get; set; }

        /// <summary>
        /// Description of the game
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// List of genre tags for the game
        /// </summary>
        [Required]
        public List<string> GenreTags { get; set; }
    }
}
