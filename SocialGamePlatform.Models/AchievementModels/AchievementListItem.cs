using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Models.AchievementModels
{
    public class AchievementListItem
    {
        /// <summary>
        /// Name of the game for the achievement
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// Name of the achievement
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the achievement
        /// </summary>
        public string Description { get; set; }
    }
}
