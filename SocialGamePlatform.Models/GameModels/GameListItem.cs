using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Models.GameModels
{
    public class GameListItem
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public decimal Price { get; set; }
        public List<string> GenreTags { get; set; }
    }
}
