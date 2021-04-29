using System.Collections.Generic;

namespace SocialGamePlatform.Models.GameModels
{
    public class GameListItem
    {
        /// <summary>
        /// Game Id
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Game name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Game average rating
        /// </summary>

        public double Rating { get; set; }

        /// <summary>
        /// Game price
        /// </summary>
        public decimal Price { get; set; }

        ///// <summary>
        ///// Genre tags for the game
        ///// </summary>
        //public List<string> GenreTags { get; set; }
    }
}
