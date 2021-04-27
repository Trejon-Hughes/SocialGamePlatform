using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Models.GameModels
{
    public class GameDetail
    {
        public string OwnerUserName { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<string> GenreTags { get; set; }
    }
}
