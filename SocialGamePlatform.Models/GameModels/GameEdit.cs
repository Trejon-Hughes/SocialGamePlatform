using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialGamePlatform.Models.GameModels
{
    public class GameEdit
    {
        /// <summary>
        /// Game Id
        /// </summary>
        [Required]
        public int GameId { get; set; }

        /// <summary>
        /// Game name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Price of the game, Max of 2 decimal places, Between 0 and 9999.99
        /// </summary>
        [Required]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Target Price; Max 18 digits")]
        public decimal Price { get; set; }

        /// <summary>
        /// Description of the game
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Genre tags for the game
        /// </summary>
        [Required]
        public List<string> GenreTags { get; set; }
    }
}
