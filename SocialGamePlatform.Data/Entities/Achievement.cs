using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Data
{
    public class Achievement
    {
        [Key]
        public int AchievementId { get; set; }

        [JsonIgnore]
        public Guid CreatorId { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        [JsonIgnore]
        public virtual Game Game { get; set; }

        public string GameName
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var game = ctx.Games.Single(e => e.GameId == GameId);
                    return game.Name;
                }
            }
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
