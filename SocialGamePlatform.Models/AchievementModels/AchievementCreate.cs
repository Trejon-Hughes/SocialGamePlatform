using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Models.AchievementModels
{
    public class AchievementCreate
    {
        /// <summary>
        /// Id for the game
        /// </summary>
        [Required]
        public int GameId { get; set; }

        /// <summary>
        /// Name of the achievement
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description of the achievement
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}
