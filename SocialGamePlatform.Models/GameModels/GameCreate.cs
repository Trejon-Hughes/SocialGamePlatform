using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
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
